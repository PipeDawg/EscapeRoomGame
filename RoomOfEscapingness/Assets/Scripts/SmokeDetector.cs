using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDetector : MonoBehaviour
{
    private AudioSource beepAudio;
    private GameObject beepLight;
    public float timeBetweenBeeps;
    private GameManager gameManager;
    private float timer = 0;
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        beepLight = GameObject.Find("SmokeDetectorLight");
        beepAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.09f && timer < 2)
        {
            beepLight.SetActive(false);
        }
        if (timer > timeBetweenBeeps && !gameManager.foundAlarmKey)
        {
            timer = 0;
            // Beep code
            Debug.Log("Timer trigger");
            beepAudio.Play();
            beepLight.SetActive(true);

        }
    }

}
