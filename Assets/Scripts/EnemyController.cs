using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    public bool vertical;
    public float enemySpeed = 2.0f;
    public float changeTime = 3.0f;
    public int enemyDamage = 2;

    float timer;
    int direction = 1;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(-enemyDamage);

        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    public void FixedUpdate()
    {
        
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + enemySpeed * Time.deltaTime * direction;

            
        }
        else
        {
            position.x = position.x + enemySpeed * Time.deltaTime * direction;


        }

        rigidbody2D.MovePosition(position);
    }

}
