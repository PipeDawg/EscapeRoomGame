using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObject : MonoBehaviour
{
    private bool isGrabbed = false;
    private Transform grabbedObject;
    private Rigidbody grabbedRigidbody;
    private float grabDistance = 2f; // Adjust the distance from the camera to the grabbed object
    private LayerMask obstacleLayer; // Layer mask for obstacles (e.g., walls)

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Change to the desired input method (e.g., Input.GetKeyDown(KeyCode.Space))
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
    }

    void TryGrabObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit,6))
        {
            if (hit.collider.CompareTag("Grabbable"))
            {
                GrabObject(hit.transform);
            }
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
        grabbedRigidbody.velocity = Camera.main.transform.forward * 10f; // Adjust the throw speed as needed
        grabbedObject = null;
        grabbedRigidbody = null;
        isGrabbed = false;
    }

    void UpdateGrabbedObjectPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 6, obstacleLayer))
        {
            // If there's an obstacle, set the target position just before the obstacle
            Vector3 targetPosition = hit.point - Camera.main.transform.forward * 0.1f;
            grabbedObject.position = Vector3.Lerp(grabbedObject.position, targetPosition, Time.deltaTime * 10f);
        }
        else
        {
            // If no obstacle, set the target position normally
            Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * grabDistance;
            grabbedObject.position = Vector3.Lerp(grabbedObject.position, targetPosition, Time.deltaTime * 10f);
        }
    }
}
