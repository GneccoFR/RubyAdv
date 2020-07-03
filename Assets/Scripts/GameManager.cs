using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterVolSlider;
    public Slider musicVolSlider;
    public Slider sfxVolSlider;

    float sliderValue = 1f;

    private static GameManager instance = null;

    public static GameManager GetInstance()
    {
        return instance;
    }

    // Use this for initialization
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetMasterVolume()
    {
        mixer.SetFloat("masterVolume", Mathf.Log10(masterVolSlider.value) * 20);
    }

    public void SetMusicVolume()
    {
        mixer.SetFloat("backVolume", Mathf.Log10(musicVolSlider.value) * 20);
    }

    public void SetSFXVolume()
    {
        mixer.SetFloat("sfxVolume", Mathf.Log10(sfxVolSlider.value) * 20);
    }
}