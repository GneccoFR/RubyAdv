using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject standAloneInstructions;
    public GameObject mobileUI;
    public GameObject mobileInstructions;
    public InGameMenu inGameMenu;
    public LoseMenu loseMenu;
    public Slider levelVolume;

    private void Awake()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        standAloneInstructions.SetActive(true);
#else
        mobileInstructions.SetActive(true);
        mobileUI.SetActive(true);
#endif
    }

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
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        standAloneInstructions.SetActive(false);
#else
        mobileInstructions.SetActive(false);
#endif
    }



    public void PauseGame()
    {
        inGameMenu.PauseGame();
    }


}
