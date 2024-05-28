using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject LaptopCam;
    [SerializeField] GameObject MainCam;
    [SerializeField] GameObject UI;
    [SerializeField] PlayerMovementNew PlayerMovement;
    public bool hasSpeech = false;
    public bool hasJacket = false;
    public bool hasShaved = false;
    public bool hasMemory = false;
    public bool foundAlarmKey = false;
    public AudioSource readyToLeave;
    private bool playedCueAúdio = false;
    public float timer;
    public bool sharonVoiceSaid = false;
    public bool blessThisMessSaid = false;
    public bool boogieJarSaid = false;

    // Start is called before the first frame update
    void Start()
    {
        LaptopCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (hasSpeech && hasJacket && !playedCueAúdio)
        {
            playedCueAúdio = true;
            readyToLeave.Play();
        }
    }

    public void SwitchCamera()
    {
        if (MainCam.activeSelf == true)
        {
            LaptopCam.SetActive(true);
            MainCam.SetActive(false);
            PlayerMovement.enabled = false;
        }
        else
        {
            MainCam.SetActive(true);
            LaptopCam.SetActive(false);
            PlayerMovement.enabled = true;
        }
    }

    public void LockMouse(bool lockState)
    {
        if (lockState)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!lockState)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void UIOn(bool type)
    {
        UI.SetActive(type);
    }


}
