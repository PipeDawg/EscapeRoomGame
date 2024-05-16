using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkScript : MonoBehaviour
{

    [SerializeField] ParticleSystem particleSys;
    private AudioSource waterSound;
    bool isOn;

    private void Start()
    {
        waterSound = GetComponent<AudioSource>();
        particleSys.Stop();
    }

    void Update()
    {
        if (GetComponent<InteractabbleBase>().triggerInteractAction)
        {
            if (isOn)
            {
                particleSys.Stop();
                isOn = false;
                if (waterSound.isPlaying)
                {
                    waterSound.Stop();
                    Debug.Log("sounds should play");
                }
            }
            else
            {
                particleSys.Play();
                isOn = true;
                if (!waterSound.isPlaying)
                {
                    waterSound.Play();
                    Debug.Log("sounds should not play");
                }
            }
        }
    }
}
