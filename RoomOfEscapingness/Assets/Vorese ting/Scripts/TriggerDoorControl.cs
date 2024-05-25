using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorControl : MonoBehaviour
{

    public bool mirrorAnim;
    private Animator doorAnimator;
    [SerializeField] private InteractabbleBase raycastScript;
    public GameObject doorObject;
    AudioSource DoorOpenSound;
    AudioSource DoorCloseSound;
    [SerializeField] bool HasLock;
    public bool Locked = true;
    public AudioSource itsLockedVoiceLine;

    public GameObject Key;

    private void Start()
    {
        if (HasLock)
        {
            Locked = true;
        }

        GameObject OpenSound = GameObject.Find("DoorOpenAudio");
        DoorOpenSound = OpenSound.GetComponent<AudioSource>();

        GameObject CloseSound = GameObject.Find("DoorCloseAudio");
        DoorCloseSound = CloseSound.GetComponent<AudioSource>();

        doorAnimator = GetComponent<Animator>();

        if (mirrorAnim)
        {
            bool Mirror = doorAnimator.GetBool("Mirror");
            doorAnimator.SetBool("Mirror", !Mirror);
        }
    }

    void Update()
    {
        if (raycastScript.triggerInteractAction)
        {
            if (!Locked)
            {
                ToggleDoorAnimation();
            }
            else
            {
                itsLockedVoiceLine.Play();
            }
        }


    }

    public void ToggleDoorAnimation()
    {


        if (!mirrorAnim)
        {
            bool isOpen = doorAnimator.GetBool("isOpen");
            Debug.Log("should open");
            doorAnimator.SetBool("isOpen", !isOpen);

            if (doorAnimator.GetBool("isOpen") == false)
            {
                DoorCloseSound.Play();
            }
            else if (doorAnimator.GetBool("isOpen") == true)
            {
                DoorOpenSound.Play();
            }
        }
        else
        {
            //bool Mirror = doorAnimator.GetBool("Mirror");
            //doorAnimator.SetBool("Mirror", Mirror = true);

            bool isOpenMirrored = doorAnimator.GetBool("isOpenMirrored");
            Debug.Log("should open mirrored");
            doorAnimator.SetBool("isOpenMirrored", !isOpenMirrored);

            if (doorAnimator.GetBool("isOpenMirrored") == false)
            {
                DoorCloseSound.Play();
            }
            else if (doorAnimator.GetBool("isOpenMirrored") == true)
            {
                DoorOpenSound.Play();
            }
        }

    }


}