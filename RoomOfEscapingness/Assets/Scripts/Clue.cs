using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Clue : MonoBehaviour
{
    [Header("Text Options:")]
    [SerializeField] public bool copyTextSize = false;
    public bool textPopup = false;

    [Header("Other:")]
    public TextMeshPro textFront;
    public TextMeshPro textBack;
    [SerializeField] GameObject playerObject;
    private GrabableObject gr;
    [HideInInspector] public bool isFacingCamera = true;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player2");
        if (playerObject != null)
        {
            gr = playerObject.GetComponent<GrabableObject>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject != null && gr.isGrabbed)
        {
            clue();
        }


    }

    void clue()
    {
        if (gr.grabbedObject == transform)
        {
            float angle = Vector3.Angle(transform.forward, Camera.main.transform.forward);
            isFacingCamera = angle > 90f;
        }
    }
}
