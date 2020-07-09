using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject mobileInstructions;
    public InGameMenu inGameMenu;
    public LoseMenu loseMenu;
    public Slider levelVolume;
    private void Start()
    {
        gameManager = GameManager.GetInstance();
    }

    public void SetLevelVolume()
    {
        gameManager.mixer.SetFloat("masterVolume", Mathf.Log10(levelVolume.value) * 20);
    }

    public void Lose()
    {
        loseMenu.Lose();
    }

    public void DisableInstructions()
    {
        mobileInstructions.SetActive(false);
    }



    public void PauseGame()
    {
        inGameMenu.PauseGame();
    }


}
