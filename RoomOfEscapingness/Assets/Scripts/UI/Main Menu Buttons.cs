using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Image fadeToWhiteImage;
    public AudioSource musicFade;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {

        StartCoroutine(StartTheGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartTheGame()
    {
        StartCoroutine(FadeTheAlpha(1));
        yield return new WaitForSeconds(2.6f);
        SceneManager.LoadSceneAsync(1);
    }
    IEnumerator FadeTheAlpha(float targetAlpha)
    {
        Color tempColor = fadeToWhiteImage.color;
        if (fadeToWhiteImage.color.a < targetAlpha)
        {
            tempColor.a += 0.005f;
            musicFade.volume -= 0.006f;
            if (tempColor.a > 1)
            {
                tempColor.a = 1; // Safety Measure
            }
        }
        else if (fadeToWhiteImage.color.a > targetAlpha)
        {
            tempColor.a -= 0.005f;
            if (tempColor.a < 0)
            {
                tempColor.a = 0; // Safety Measure
            }
        }
        fadeToWhiteImage.color = tempColor;
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(FadeTheAlpha(targetAlpha));
    }
}
