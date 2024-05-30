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
    public bool foundAlarmKey = false;
    public AudioSource readyToLeave;
    private bool playedCueAúdio = false;
    public float timer;
    public bool sharonVoiceSaid = false; // Above
    public bool blessThisMessSaid = false; // Above, below, and this is for voice lines that should only play once
    public bool boogieJarSaid = false; // Below
    [SerializeField] GameObject menuScreen;
    public MoveCam MoveCam;

    // Start is called before the first frame update
    void Start()
    {
        LaptopCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (hasSpeech && hasJacket && !playedCueAúdio) // if all objectives complete :P
        {
            playedCueAúdio = true;
            readyToLeave.Play();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuScreen.SetActive(!menuScreen.activeSelf);
            if(menuScreen.activeSelf)
            {
                LockMouse(true);
                MoveCam.enabled = true;
            }
            else
            {
                LockMouse(false);
                MoveCam.enabled = false;
            }
        }
    }

    public void SwitchCamera()
    {
        if (MainCam.activeSelf)
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
