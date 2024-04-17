using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LaptopScript : MonoBehaviour
{
    [SerializeField] InteractabbleBase InteractableScript;
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
        if (_zoomedIn == true && Input.GetKeyDown(KeyCode.E))
        {
            _zoomedIn = false;
            gameManager.SwitchCamera();
            Debug.Log("zoomed out");

        } else if (_zoomedIn == false && InteractableScript.triggerInteractAction)
        {
            _zoomedIn = true;
            gameManager.SwitchCamera();
            gameManager.LockMouse(true);
            Debug.Log("zoomed in");
        }

        if (_zoomedIn && Input.GetKeyDown(KeyCode.Mouse0))
        {
            LoggedIn();
        }

    }

    void LoggedIn()
    {
        ScreenObject.GetComponent<MeshRenderer>().material = LoggedInTexture;
        _loggedIn = true;
    }

}
