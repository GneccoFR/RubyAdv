using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject inGameMenu;
    
    private void Update()
    {
        if (inGameMenu.activeSelf == true)
            Time.timeScale = 0;
    }

    public void ReturnTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        inGameMenu.SetActive(false);
    }
}
