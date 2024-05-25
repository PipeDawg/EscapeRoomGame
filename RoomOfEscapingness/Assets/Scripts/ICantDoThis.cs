using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICantDoThis : MonoBehaviour
{
    public GameObject player;
    private GameManager gameManager;
    public AudioSource iCantDoThisSound;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if(gameManager.hasJacket && gameManager.hasSpeech)
        {
            if (gameObject.name == "DestroyWhenPlayerWon")
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == player.name && !gameManager.hasSpeech && !gameManager.hasJacket)
        {
            // Stop player from leaving
            player.GetComponent<PlayerMovementNew>().sprintSpeed = 0.7f;
            player.GetComponent<PlayerMovementNew>().walkSpeed = 0.7f;
            iCantDoThisSound.Play();
        }
        else
        {
            Debug.Log("Player Won");
            return;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == player.name)
        {
            // Reset players movement so it doesn't fuck up lol
            player.GetComponent<PlayerMovementNew>().sprintSpeed = 2;
            player.GetComponent<PlayerMovementNew>().walkSpeed = 2;
        }
        else
        {
            return;
        }
    }
}
