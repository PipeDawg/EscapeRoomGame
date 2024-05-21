using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerCam : MonoBehaviour
{
    public Transform cameraPosition;

    // Start is called before the first frame update
    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
