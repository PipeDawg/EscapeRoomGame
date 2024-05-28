using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicheVoiceLines : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource sharonVA;
    public AudioSource boogieJarVA;
    public AudioSource blessThisMessVA;
    public int whichVoiceLine;
    private float timeBetweenVA;

    void Update()
    {
        timeBetweenVA += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        if (whichVoiceLine == 1 && !gameManager.sharonVoiceSaid && gameManager.timer >= 20 && timeBetweenVA >= 15)
        {
            sharonVA.Play();
            timeBetweenVA = 0;
            gameManager.sharonVoiceSaid = true;
        }
        else if (whichVoiceLine == 2 && !gameManager.boogieJarSaid && gameManager.timer >= 55 && timeBetweenVA >= 20)
        {
            boogieJarVA.Play();
            timeBetweenVA = 0;
            gameManager.boogieJarSaid = true;
        }
        else if(whichVoiceLine == 3 && !gameManager.blessThisMessSaid && gameManager.timer >= 150 && timeBetweenVA >= 15)
        {
            blessThisMessVA.Play();
            timeBetweenVA = 0;
            gameManager.blessThisMessSaid = true;
        }
    }
}
