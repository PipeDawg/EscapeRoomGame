using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    private TMP_Text text;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = "To go to your sons funeral, you must:\n- Print out your speech [" + Convert.ToInt32(gameManager.hasSpeech) + "/1]\n- Get your suit from the closet [" + Convert.ToInt32(gameManager.hasJacket) + "/1]";
    }
}
