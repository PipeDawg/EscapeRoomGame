using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour
{
    public GameObject[] lights;
    public bool thisState = false;
    AudioSource LightSwitchAudio;
    [SerializeField] InteractabbleBase interactabble;
    [SerializeField] Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        LightSwitchAudio = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisState == true || thisState == false)
        {
            ChangeLightIntensity();
        }
        if (interactabble.triggerInteractAction)
        {
            FlipthisState();
            animator.SetBool("On",thisState);
        }

    }

    public void FlipthisState()
    {
        thisState = !thisState;
        Debug.Log("thisState flipped");
    }

    void ChangeLightIntensity()
    {
        foreach (GameObject lightObject in lights)
        {
            // Check if the GameObject has a Light component
            Light lightComponent = lightObject.GetComponent<Light>();

            if (/*lightComponent != null && */thisState == false)
            {
                // Decrease the intensity (adjust the factor as needed)
                lightComponent.intensity = 0f; // You can use a different factor or value
            } else
            {
                lightComponent.intensity = 1f;
            }
        }
    }
}
