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
            Debug.Log("TAKING SPEECH");
            gameManager.hasSpeech = true;
            Destroy(gameObject);
        }
    }
}
