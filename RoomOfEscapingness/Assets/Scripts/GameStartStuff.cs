using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartStuff : MonoBehaviour
{
    public AudioSource myHeadHurtsVoiceLine;
    public AudioSource iShouldPrepareVoiceLine;
    public Image fadeAwayImage;
    void Start()
    {
        StartCoroutine(GameInitiation());
        StartCoroutine(PlayStartVoiceLines());
    }

    IEnumerator GameInitiation()
    {
        Color tempColor = fadeAwayImage.color;
        if (fadeAwayImage.color.a > 0)
        {
            tempColor.a -= 0.003f;
            if (tempColor.a < 0)
            {
                tempColor.a = 0; // Safety Measure
            }
        }
        fadeAwayImage.color = tempColor;
        yield return new WaitForSeconds(0.01f);
        if(fadeAwayImage.color.a != 0)
        {
            StartCoroutine(GameInitiation());
        }
    }

    IEnumerator PlayStartVoiceLines()
    {
        yield return new WaitForSeconds(1);
        myHeadHurtsVoiceLine.Play();
        yield return new WaitForSeconds(11);
        iShouldPrepareVoiceLine.Play();
    }

}
