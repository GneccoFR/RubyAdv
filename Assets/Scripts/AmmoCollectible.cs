using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    public int ammoAmount = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.currentAmmo < controller.maxAmmo)
            {
                controller.PickEffect();
                controller.PlaySound(collectedClip);
                controller.currentAmmo += ammoAmount;
                controller.RecountAmmo();
                Destroy(gameObject);
            }
        }
    }
}
