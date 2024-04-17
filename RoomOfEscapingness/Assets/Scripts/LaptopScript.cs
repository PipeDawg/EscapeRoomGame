using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;

public class LaptopScript : MonoBehaviour
{
    [SerializeField] InteractabbleBase InteractableScript;
    [SerializeField] PrintIconScript IconScript;

    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject ScreenObject;

    [SerializeField] Material LockedTexture;
    [SerializeField] Material LoggedInTexture;

    public bool _loggedIn = false;
    public bool _zoomedIn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractableScript.triggerInteractAction)
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

        if (_zoomedIn && Input.GetKeyDown(KeyCode.Mouse0))
        {
            LoggedIn();
        }

        if (_zoomedIn && _loggedIn)
        {
            LaptopOS();
        }
    }
    void LoggedIn()
    {
        ScreenObject.GetComponent<MeshRenderer>().material = LoggedInTexture;
        _loggedIn = true;
    }

    void LaptopOS()
    {
        if (IconScript.clickedTwice)
        {
            Debug.Log("printing");
        }
    }

}
