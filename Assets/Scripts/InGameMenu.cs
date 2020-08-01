using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    CanvasScript canvasScript;
    private bool active = false;
    
    private void Update()
    {
        if (!active) return;
        if (Input.GetKeyDown(KeyCode.Escape)) ResumeGame();
    }

    public void PauseGame()
    {
        active = true;
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void ReturnTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        active = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
