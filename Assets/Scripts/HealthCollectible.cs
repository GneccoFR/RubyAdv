using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    public int cureAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
                controller.PickEffect();
                controller.PlaySound(collectedClip);
                controller.ChangeHealth(cureAmount);
                Destroy(gameObject);
            }        
        }
    }
}
