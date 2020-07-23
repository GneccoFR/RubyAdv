using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Jambi jambi;
    public static QuestManager instance = null;
    //this class should manage the game objectives
    public int maxRobots = 5; // + LevelManager.setdifficult;
    int robotsFixed = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public static QuestManager GetInstance()
    {
        return instance;
    }

    // Fix all the Robots
    // The more the robots, the more de difficulty
    public void RobotFixed()
    {
        robotsFixed += 1;
        Debug.Log(robotsFixed);
        if (robotsFixed == maxRobots)
        {
            jambi.QuestCompleted();
        }
    }

   // Collect all the fruits
   
   
}
