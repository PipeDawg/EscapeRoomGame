using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteReader : MonoBehaviour
{
    public GameObject myNoteCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            myNoteCanvas.SetActive(true);
        }
        else
        {
            myNoteCanvas.SetActive(false);
        }
    }


}
