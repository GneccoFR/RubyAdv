using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour 
{
    public GameManager manager;
    public GameObject optionsMenu;
    public GameObject mainMenu;
    public void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void LoadGame() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    
    }

    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void QuitGame ()
    {
      
        Application.Quit();
    }

}
