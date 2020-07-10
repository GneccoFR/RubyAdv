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
    public GameObject mobileHelpButton;
    public GameObject mobileInstructions;
    public InGameMenu inGameMenu;
    public LoseMenu loseMenu;
    public Slider levelVolume;

    private void Awake()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        standAloneInstructions.SetActive(true);
#else
        mobileHelpButton.SetActive(true);
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
    
    public void OnOffInstructions()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        if (standAloneInstructions.activeSelf == true)
            standAloneInstructions.SetActive(false);
        else standAloneInstructions.SetActive(true);
#else
        if (mobileInstructions.activeSelf == true)
            mobileInstructions.SetActive(false);
        else 
        {
            inGameMenu.ResumeGame();
            mobileInstructions.SetActive(true);
        }
#endif
    }



    public void PauseGame()
    {
        inGameMenu.PauseGame();
    }


}
