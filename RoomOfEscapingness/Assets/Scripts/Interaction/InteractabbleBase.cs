using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractabbleBase : MonoBehaviour
{
    [HideInInspector] public GameObject playerObject;
    public bool triggerInteractAction;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        triggerInteractAction = false;
        //Debug.Log("Didn't Interact With Object");
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (playerObject.GetComponent<InteractLookCheck>().LookingAt(gameObject))
            {
                triggerInteractAction = true;
                //Debug.Log("Interacted With Object");
            }
        }
    }
}