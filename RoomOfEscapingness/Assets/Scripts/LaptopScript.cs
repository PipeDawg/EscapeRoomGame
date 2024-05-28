using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LaptopScript : MonoBehaviour
{
    [SerializeField] InteractabbleBase InteractableScript;
    [SerializeField] PrintIconScript IconScript;

    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject ScreenObject;
    [SerializeField] TMP_InputField Inputfield;
    [SerializeField] GameObject Printer;

    [SerializeField] Material LockedTexture;
    [SerializeField] Material LoggedInTexture;
    public AudioSource[] wrongPasswordSounds;
    private int randomNum;

    public bool _loggedIn = false;
    public bool _zoomedIn = false;

    [SerializeField] string Password;
    // Start is called before the first frame update
    void Start()
    {
        gameManager.UIOn(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractableScript.triggerInteractAction && !Inputfield.isFocused)
        {
            if (_zoomedIn) // if using then dont use
            {
                _zoomedIn = false;
                gameManager.SwitchCamera();
                gameManager.LockMouse(true);
                Debug.Log("zoomed out");
            }
            else if (!_zoomedIn) // if not using then use
            {
                gameManager.SwitchCamera();
                gameManager.LockMouse(false);
                Debug.Log("zoomed in");
                _zoomedIn = true;
            }
        }

        if (!_loggedIn && _zoomedIn)
        {
            gameManager.UIOn(true);
        } else if (!_loggedIn && !_zoomedIn)
        {
            gameManager.UIOn(false);
        }

        if (_zoomedIn && _loggedIn)
        {
            LaptopOS();
        }
    }
    
    public void PassWordLogin() // checks if the typed password is correct
    {
        if (Inputfield.text == Password)
        {
            Debug.Log("Logging on...");
            LoggedIn();
        }
        else
        {
            randomNum = UnityEngine.Random.Range(0, 2);
            wrongPasswordSounds[randomNum].Play();
        }
    }

    void LoggedIn() // changes the material to the background image of Windows XP
    {
        ScreenObject.GetComponent<MeshRenderer>().material = LoggedInTexture;
        _loggedIn = true;
        gameManager.UIOn(false);
    }

    void LaptopOS() // Checks if the print icon has been clicked twice to print it
    {
        if (IconScript.clickedTwice)
        {
            Printer.GetComponent<PrintSpeech>().PrintSpeechPaper();
        }
    }

}
