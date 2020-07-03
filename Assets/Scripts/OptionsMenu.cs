using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameManager manager;
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void MainMenu()
    {   
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
