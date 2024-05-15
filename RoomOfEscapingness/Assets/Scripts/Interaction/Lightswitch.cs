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
            animator.SetBool("On",  thisState);
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
            if (/*lightComponent != null && */thisState == false)
            {
                lightObject.SetActive(false);
            } else
            {
                lightObject.SetActive(true);
            }
        }
    }
}
