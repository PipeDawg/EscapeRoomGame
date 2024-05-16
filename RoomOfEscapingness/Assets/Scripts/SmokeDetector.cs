using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDetector : MonoBehaviour
{
    private AudioSource beepAudio;
    private GameObject beepLight;
    public float timeBetweenBeeps;
    private float timer = 0;
    private void Start()
    {
        beepLight = GameObject.Find("SmokeDetectorLight");
        beepAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.04f && timer < 1)
        {
            beepLight.SetActive(false);
        }
        if (timer > timeBetweenBeeps)
        {
            timer = 0;
            // Beep code
            Debug.Log("Timer trigger");
            beepAudio.Play();
            beepLight.SetActive(true);

        }
    }

}
