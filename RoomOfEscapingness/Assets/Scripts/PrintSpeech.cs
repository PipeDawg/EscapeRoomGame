using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintSpeech : MonoBehaviour
{
    private InteractabbleBase interactable;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        interactable = GetComponent<InteractabbleBase>();
    }
    private void Update()
    {
        if (interactable.triggerInteractAction)
        {
            PrintSpeechPaper();
        }
    }

    public void PrintSpeechPaper()
    {
        
    }
}
