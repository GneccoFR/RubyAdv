﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public GameObject dialogBox;
    public float displayTime = 4.0f;
    float timerDisplay;
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }

    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
                dialogBox.SetActive(false);
        }
    }
}
