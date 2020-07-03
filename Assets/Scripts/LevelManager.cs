using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelManager : MonoBehaviour
{
    public AudioMixer mixer;
    //private GameManager gameManager;
    public Slider levelVolume;
    private void Awake()
    {
        //gameManager = GameManager.GetInstance();
        //setdifficult = difficult;
    }

    public void SetLevelVolume()
    {
        mixer.SetFloat("masterVolume", Mathf.Log10(levelVolume.value) * 20);
    }
}
