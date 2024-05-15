using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpToInventory : MonoBehaviour
{
    private InteractabbleBase interactable;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        interactable = GetComponent<InteractabbleBase>();
    }
    void Update()
    {
        if (interactable.triggerInteractAction)
        {
            if (gameObject.name == "SpeechPaper")
            {
                gameManager.hasSpeech = true;
                Debug.Log("TAKING SPEECH");
                Destroy(gameObject);
            } else if(gameObject.name == "Jacket")
            {
                gameManager.hasJacket = true;
                Debug.Log("TAKING JACKET");
                Destroy(gameObject);
            }
        }
    }
}
