using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NoteReader : MonoBehaviour
{
    public TMP_Text clueText;
    [SerializeField] List<GameObject> clueNotes;
    public InteractLookCheck lookScript;


    void Update()
    {
        clueText.text = "";

        for (int i = 0; i < clueNotes.Count; i++)
        {
            
            if (lookScript.LookingAt(clueNotes[i]))
            {

                clueText.text = clueNotes[i].GetComponentInChildren<TextMeshPro>().text;

            }
        }
    }


}
