using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GrabableObject : MonoBehaviour
{
    [SerializeField] MoveCam mouseLook;
    private InteractLookCheck lookcheck;

    public bool isGrabbed = false;
    public Transform grabbedObject;
    private Rigidbody grabbedRigidbody;
    [SerializeField] float grabDistance = 1f; // Adjust the distance from the camera to the grabbed object
    [SerializeField] LayerMask obstacleLayer; // Layer mask for obstacles (e.g., walls)
    private bool inspectState;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public float sensitivity = 2.0f;

    // Update is called once per frame

    private void Start()
    {
        mouseLook = GameObject.FindWithTag("MainCamera").GetComponent<MoveCam>();
        lookcheck = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractLookCheck>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Change to the desired input method (e.g., Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGrabbed)
            {
                TryGrabObject();
            }
            else
            {
                ReleaseObject();
            }
        }

        if (isGrabbed)
        {
            UpdateGrabbedObjectPosition();
        }

        if (inspectState && isGrabbed)
        {
            inspectMechanic();

            if (mouseLook.isActiveAndEnabled)
            {
                mouseLook.enabled = false;
                gameObject.GetComponent<PlayerMovementNew>().enabled = false;
            }
        } else if (!inspectState) 
        {
            if (!mouseLook.isActiveAndEnabled)
            {
                gameObject.GetComponent<PlayerMovementNew>().enabled = true;
                mouseLook.enabled = true;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (!inspectState)
            {
                inspectState = true;
            }
        } 
        else
        {
            if (inspectState)
            {
                inspectState = false;
            }
        }
    }

    void TryGrabObject()
    {
        if (lookcheck.hitObject != null && lookcheck.hitObject.CompareTag("Grabbable"))
        {
            GrabObject(lookcheck.hitObject.transform);
        }
    }

    void GrabObject(Transform objectToGrab)
    {
        grabbedObject = objectToGrab;
        grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
        grabbedRigidbody.isKinematic = true;
        isGrabbed = true;
    }

    void ReleaseObject()
    {
        grabbedRigidbody.isKinematic = false;
        if (grabbedObject.name.Contains("Beer"))
        {
            grabbedRigidbody.velocity = Camera.main.transform.forward * 5f; // Adjust the throw speed as needed
        }

        grabbedObject = null;
        grabbedRigidbody = null;
        isGrabbed = false;
        inspectState = false;
    }

    void UpdateGrabbedObjectPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, lookcheck.interactionRange, obstacleLayer))
        {
            // If there's an obstacle, set the target position just before the obstacle
            Vector3 targetPosition = hit.point - Camera.main.transform.forward * 0.1f;
            grabbedObject.position = Vector3.Lerp(grabbedObject.position, targetPosition, Time.deltaTime * 100f);
        }
        else
        {
            // If no obstacle, set the target position normally
            Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * grabDistance;
            grabbedObject.position = Vector3.Lerp(grabbedObject.position, targetPosition, Time.deltaTime * 10f);
        }
    }

    void inspectMechanic()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX += mouseY * sensitivity;
        rotationY += mouseX * sensitivity;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        grabbedObject.rotation = Quaternion.Euler(-rotationX, rotationY, 0.0f);
    }
}

