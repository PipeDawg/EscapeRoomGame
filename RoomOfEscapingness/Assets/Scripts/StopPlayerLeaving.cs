using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPlayerLeaving : MonoBehaviour
{
    // Quick junk script
    public GameManager manager;
    private BoxCollider stopper;
    public GameObject objectiveText;
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            return;
        }
        if(!manager.hasSpeech)
        {
            objectiveText.SetActive(true);
        }
    }
}
