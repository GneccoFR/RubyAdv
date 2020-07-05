using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jambi : NonPlayerCharacter
{
    [SerializeField]
    AudioClip questComplete;
    
    override public void QuestCompleted()
    {
        dialogBox.GetComponentInChildren<TextMeshProUGUI>().text = "You did it! You Fixed All The Robots!";
        audioSource.PlayOneShot(questComplete);
    }

}
