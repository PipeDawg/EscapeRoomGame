using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLookCheck : MonoBehaviour
{
    public float interactionRange;
    // Start is called before the first frame update
    public bool LookingAt(GameObject target)
    {
        Camera mainCamera = Camera.main;

        // Check if the main camera is not assigned
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Make sure you have a camera tagged as 'MainCamera' in your scene.");
            return false;
        }

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactionRange))
        {
            // Check if the hit object is the same as the target
            return hit.collider.gameObject == target;
        }

        return false;
    }

}
