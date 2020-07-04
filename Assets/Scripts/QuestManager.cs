using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public NonPlayerCharacter NPC;
    //public AudioSource audioSource;
    public static QuestManager instance = null;
    //this class should manage the game objectives
    public TextMeshProUGUI dialog;
    int maxRobots = 5; // + LevelManager.setdifficult;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        //audioSource = NPC.GetComponent<AudioSource>();
    }

    public static QuestManager GetInstance()
    {
        return instance;
    }

    // Fix all the Robots
    // The more the robots, the more de difficulty
    public void CheckRobotFix(int count)
    {
        maxRobots = maxRobots - count;
        Debug.Log(maxRobots);
        if (maxRobots <= 0)
        {
            //NPC.Greeting();
            dialog.text = "You did it! You Fixed All The Robots!";
        }
    }

   // Collect all the fruits
   
    
    // Not diying
}
