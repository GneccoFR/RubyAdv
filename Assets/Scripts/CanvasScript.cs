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

    /*
    private static CanvasScript instance = null;

    public static CanvasScript GetInstance()
    {
        return instance;
    }

    private void Singleton()
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
    */
    void Awake()
    {
        //Singleton();
        animator = GetComponent<Animator>();
        OpenTitle();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && mainMenuIsActive == false)
            SwapMenus();
    }

    /*
    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnTitleLoaded;
    }

    public void OnTitleLoaded(Scene scene, LoadSceneMode mode)
    {
        OpenTitle();
    }
    */

    public void OpenTitle()
    {
        //animator = GetComponent<Animator>();
        Time.timeScale = 1.0f;
        animator.SetTrigger("MainOpen");
        mainMenuIsActive = true;
        manager = GameManager.GetInstance();
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
