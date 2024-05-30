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
    public float timer2;
    public bool sharonVoiceSaid = false;
    public bool blessThisMessSaid = false;
    public bool boogieJarSaid = false;
    public GameObject menuScreen;
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
                Cursor.lockState = CursorLockMode.None;
                MoveCam.enabled = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
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
