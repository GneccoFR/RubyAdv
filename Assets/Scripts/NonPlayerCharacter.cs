using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    protected AudioSource audioSource;
    [SerializeField]
    protected GameObject dialogBox;
    [SerializeField]
    float displayTime = 3.0f;
    float timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
                dialogBox.SetActive(false);
        }
    }

    public virtual void QuestCompleted()
    {

    }

    public virtual void Interact()
    {
        if (timerDisplay <= 0)
        {
            timerDisplay = displayTime;
            dialogBox.SetActive(true);
        }
        else
        {
            timerDisplay = 0;
        }
    }
}
