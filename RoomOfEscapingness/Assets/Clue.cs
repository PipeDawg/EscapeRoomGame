using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        gr = playerObject.GetComponent<GrabableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gr.grabbedObject == transform)
        {
            float angle = Vector3.Angle(transform.forward, playerObject.transform.forward);
            isFacingCamera = angle > 90f;
        }
    }
}
