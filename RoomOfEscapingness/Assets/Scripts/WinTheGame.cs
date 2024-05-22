using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WinTheGame : MonoBehaviour
{
    public Image fadeToWhiteImage;
    public GameObject text;

    IEnumerator FadeTheAlpha(float targetAlpha)
    {
        Color tempColor = fadeToWhiteImage.color;
        if(fadeToWhiteImage.color.a < targetAlpha)
        {
            tempColor.a += 0.002f;
            if(tempColor.a > 1)
            {
                tempColor.a = 1; // Safety Measure
            }
        }
        else if (fadeToWhiteImage.color.a > targetAlpha)
        {
            tempColor.a -= 0.002f;
            if (tempColor.a < 0)
            {
                tempColor.a = 0; // Safety Measure
            }
        }
        fadeToWhiteImage.color = tempColor;
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(FadeTheAlpha(targetAlpha));
    }

    IEnumerator ShowWinText()
    {
        yield return new WaitForSeconds(7);
        text.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeTheAlpha(1));
            StartCoroutine(ShowWinText());
        }
    }
}
