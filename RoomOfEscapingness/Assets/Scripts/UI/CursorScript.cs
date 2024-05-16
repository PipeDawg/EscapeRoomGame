using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public List<Sprite> cursorList = new List<Sprite>();
    // 0 = Dot if the player is not looking at anything they can interact with
    // 1 = Ring if the player is looking at something they can interact with
    // 2 = Arrows if the player is currently holding an object
    [SerializeField] InteractLookCheck interactLookCheck;
    private int cursorState = 0;
    private Image cursorImage;
    private GrabableObject grabberScript;
    private RectTransform imageTransform;
    void Start()
    {
        cursorImage = GetComponent<Image>();
        interactLookCheck = GameObject.FindWithTag("Player").GetComponent<InteractLookCheck>();
        grabberScript = GameObject.FindWithTag("Player").GetComponent<GrabableObject>();
        imageTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        interactLookCheck.LookingAt(gameObject);
        if(interactLookCheck.hitObject == null)
        {
            cursorState = 0;
            imageTransform.sizeDelta = new Vector2(8, 8);
        }
        else if(interactLookCheck.hitObject.tag == "Grabbable" && !grabberScript.isGrabbed)
        {
            cursorState = 1;
            imageTransform.sizeDelta = new Vector2(25, 25);
        }
        else if (grabberScript.isGrabbed)
        {
            cursorState = 2;
            imageTransform.sizeDelta = new Vector2(90, 90);
        }
        else
        {
            cursorState = 0;
            imageTransform.sizeDelta = new Vector2(8,8);
        }
        cursorImage.sprite = cursorList[cursorState];
    }
}
