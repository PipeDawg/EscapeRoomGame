using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class DoorKeyScript : MonoBehaviour
{
    [SerializeField] private TriggerDoorControl DoorScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (DoorScript.Key != null && collision.gameObject == DoorScript.Key)
        {
            DoorScript.Locked = false;
        }
    }
}
