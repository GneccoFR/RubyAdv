using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanillaEnemy : Enemy
{
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        ProjectileCollision(collision);
        PlayerCollision(collision);
        WallCollision(collision);
    }

    void FixedUpdate()
    {
        PhysicalMove();
    }

    public override void MovementPattern(bool mybonk)
    {

        if (mybonk == true)
        {
            Debug.Log("BONK!");
            timer = 0;
            mybonk = false;
        }

        
        if (direction == Vector2.right && timer <= 0)
        {
            direction = Vector2.up;
            timer = changeTime;
        }

        if (direction == Vector2.up && timer <= 0)
        {
            direction = Vector2.left;
            timer = changeTime;
        }

        if (direction == Vector2.left && timer <= 0)
        {
            direction = Vector2.down;
            timer = changeTime;
        }

        if (direction == Vector2.down && timer <= 0)
        {
            direction = Vector2.right;
            timer = changeTime;
        }

        timer -= Time.deltaTime;
        Debug.Log(timer);
    }
}
