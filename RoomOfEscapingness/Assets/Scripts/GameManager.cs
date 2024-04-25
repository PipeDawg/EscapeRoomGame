using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject LaptopCam;
    [SerializeField] GameObject MainCam;
    [SerializeField] GameObject UI;
    public bool hasSpeech = false;
    public bool hasJacket = false;
    public bool hasShaved = false;
    public bool hasMemory = false;

    // Start is called before the first frame update
    void Start()
    {
        LaptopCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCamera()
    {
        if (MainCam.activeSelf == true)
        {
            LaptopCam.SetActive(true);
            MainCam.SetActive(false);
        }
        else
        {
            MainCam.SetActive(true);
            LaptopCam.SetActive(false);
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
