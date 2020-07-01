using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriterenderer;
    
    //For turning effect. 
    bool turn = true;
    
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();

        if (e != null)
            e.Fix();

        Destroy(gameObject);
    }

    void Update()
    {
        //Adds a little turning effect by flipping the sprite instead of makiing a whole animation for it.
        spriterenderer.flipX = turn;
        turn = !turn;

        if (transform.position.magnitude > 1000.0f)
            Destroy(gameObject);
    }
}
