using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTheGame : MonoBehaviour
{
    public Image fadeToWhiteImage;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            fadeToWhiteImage.CrossFadeAlpha(255, 3, true);
        }
    }
}
