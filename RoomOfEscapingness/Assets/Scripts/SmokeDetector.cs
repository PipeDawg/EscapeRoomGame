using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDetector : MonoBehaviour
{
    private AudioSource beepAudio;
    private GameObject beepLight;
    //public float timeBetweenBeeps; Doesn't work for some weird reason, just hard-coding it instead i guess.
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
        if (timer > /*timeBetweenBeeps*/ 30 && !gameManager.foundAlarmKey)
        {
            Debug.Log("Timer trigger at " + timer);
            timer = 0;
            // Beep code
            beepAudio.Play();
            beepLight.SetActive(true);

        }
    }

}
