using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintIconScript : MonoBehaviour
{
    int click = 0;
    public bool clickedTwice = false;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        click++;
        if (click >= 2 && !clickedTwice)
        {
            clickedTwice = true;
        }
    }
}
