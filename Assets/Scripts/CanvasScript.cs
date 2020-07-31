using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public GameManager manager;
    public GameObject optionsMenu;
    public GameObject mainMenu;
    Animator animator;
    public bool mainMenuIsActive;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("MainOpen");
        mainMenuIsActive = true;
        manager = GameManager.GetInstance();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mainMenuIsActive == false) 
            SwapMenus();
    }

    public void SwapMenus()
    {
        if (mainMenuIsActive == true)
        {
            animator.SetTrigger("MainClose");
            animator.SetTrigger("OptOpen");
        }
        else
        {
            animator.SetTrigger("OptClose");
            animator.SetTrigger("MainOpen");
        }
        mainMenuIsActive = !mainMenuIsActive;
    }

    public void LoadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
        animator.SetTrigger("MainClose");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
