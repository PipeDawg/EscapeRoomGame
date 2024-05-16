using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PrintSpeech : MonoBehaviour
{
    private InteractabbleBase interactable;
    public Animator animator;
    public GameObject speechPaperObject;
    private AudioSource audioSource;
    private void Start()
    {
        //animator = GetComponentInChildren<Animator>();
        interactable = GetComponent<InteractabbleBase>();
        audioSource = GetComponent<AudioSource>();
    }
    public void PrintSpeechPaper()
    {
        if(speechPaperObject != null)
        {
            speechPaperObject.SetActive(true);
            Debug.Log("Works");
            animator.SetBool("StartAnimation", true);
            audioSource.Play();
        } else
        {
            Debug.Log("NO MORE PAPER :(");
        }
    }
}
