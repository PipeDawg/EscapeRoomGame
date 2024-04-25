using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerLeaving : MonoBehaviour
{
    // Quick junk script
    public GameManager manager;
    private BoxCollider stopper;
    private void Awake()
    {
        stopper = GetComponent<BoxCollider>();
    }
    void Update()
    {
        if (manager.hasSpeech)
        {
            stopper.enabled = false;
        }
    }
}
