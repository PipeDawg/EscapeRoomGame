using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public List<Sprite> cursorList = new List<Sprite>();
    // 0 = Dot
    // 1 = Ring
    // 2 = Arrows
    [SerializeField] InteractLookCheck interactLookCheck;
    private int cursorState = 0;
    private Image cursorImage;
    void Start()
    {
        cursorImage = GetComponent<Image>();
        interactLookCheck = GameObject.FindWithTag("Player").GetComponent<InteractLookCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        interactLookCheck.LookingAt(gameObject);
        Debug.Log(cursorState);
        Debug.Log(interactLookCheck.hitObject.GetComponent<GrabableObject>().isGrabbed);
        if(interactLookCheck.tag == "Grabbable")
        {
            if(cursorState == 0 && !interactLookCheck.hitObject.GetComponent<GrabableObject>().isGrabbed)
            {
                cursorState = 1;
            }
            else if (interactLookCheck.hitObject.GetComponent<GrabableObject>().isGrabbed)
            {
                cursorState = 2;
            }
            else
            {
                cursorState = 0;
            }
        }

        cursorImage.sprite = cursorList[cursorState];
    }
}
