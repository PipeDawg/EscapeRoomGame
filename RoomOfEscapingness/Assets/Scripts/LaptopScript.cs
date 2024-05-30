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
    [SerializeField] AudioSource[] wrongPasswordSounds;

    public bool _loggedIn = false;
    public bool _zoomedIn = false;

    [SerializeField] string Password;
    void Start()
    {
        gameManager.UIOn(false);
    }

    void Update()
    {
        if (InteractableScript.triggerInteractAction && !Inputfield.isFocused)
        {
            if (_zoomedIn)
            {
                _zoomedIn = false;
                gameManager.SwitchCamera();
                gameManager.LockMouse(true);
                Debug.Log("zoomed out");
            }
            else if (!_zoomedIn)
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
    
    public void PassWordLogin()
    {
        if (Inputfield.text == Password)
        {
            Debug.Log("Logging on...");
            LoggedIn();
        }
        else
        {
            wrongPasswordSounds[UnityEngine.Random.Range(0, 2)].Play();
        }
    }

    void LoggedIn()
    {
        ScreenObject.GetComponent<MeshRenderer>().material = LoggedInTexture;
        _loggedIn = true;
        gameManager.UIOn(false);
    }

    void LaptopOS()
    {
        if (IconScript.clickedTwice)
        {
            Printer.GetComponent<PrintSpeech>().PrintSpeechPaper();
        }
    }

}
