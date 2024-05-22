using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NoteReader : MonoBehaviour
{
    public TMP_Text clueText;
    public GrabableObject grabobject;
    public InteractLookCheck lookScript;
    public GameObject textBackground;

    private void Start()
    {
        grabobject = FindAnyObjectByType<GrabableObject>();
    }

    void Update()
    {
        clueText.text = "";

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, lookScript.interactionRange))
        {
            if (grabobject.grabbedObject == hit.transform)
            {
                Clue clue = hit.collider.GetComponent<Clue>();
                if (clue != null)
                {
                    if (clue.textPopup == true)
                    {
                        if (clue.isFacingCamera)
                        {
                            clueText.text = clue.textFront.text;
                            if (clue.copyTextSize == true)
                            {
                                clueText.fontSize = clue.textFront.fontSize;
                            }
                        }
                        else
                        {
                            clueText.text = clue.textBack.text;
                            if (clue.copyTextSize == true)
                            {
                                clueText.fontSize = clue.textBack.fontSize;
                            }
                        }
                    }
                }
            }
            
        }


            /*
            for (int i = 0; i < clueNotes.Count; i++)
            {

                if (lookScript.LookingAt(clueNotes[i]))
                {

                    clueText.text = clueNotes[i].GetComponentInChildren<TextMeshPro>().text;
                    clueText.fontSize = clueNotes[i].GetComponentInChildren<TextMeshPro>().fontSize;

                }
            }
            */

            textBackground.SetActive(false);

        if (clueText.text != "")
        {
            textBackground.SetActive(true);
        }
    }


}
