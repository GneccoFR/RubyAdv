using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //[SerializeField]
    //protected EnemyController enemyController;
    protected QuestManager questManager;
    protected AudioSource audioSource;
    protected Rigidbody2D rigidbody2D;
    protected Animator animator;
    public AudioClip bonkClip;
    public AudioClip fixClip;
    public ParticleSystem smokeEffect;
    public ParticleSystem hitEffect;
    
    protected bool broken = true;
    public int enemyDamage;

    protected bool bonk;
    protected Vector2 direction = Vector2.right;
    public float changeTime = 3.0f;
    protected float timer;
    public float enemySpeed = 2.0f;

    protected void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        questManager = QuestManager.GetInstance();
        //enemyController = EnemyController.GetInstance();
        timer = changeTime;
    }

    protected void ProjectileCollision(Collision2D collision)
    {
        Projectile projectileCollided = collision.gameObject.GetComponent<Projectile>();
        if (projectileCollided != null)
        {
            audioSource.PlayOneShot(bonkClip);
            Fix();
        }
    }

    protected void PlayerCollision(Collision2D collision)
    {
        RubyController playerCollided = collision.gameObject.GetComponent<RubyController>();
        if (playerCollided != null)
        {
            audioSource.PlayOneShot(bonkClip);
            playerCollided.ChangeHealth(-enemyDamage);
        }
    }

    protected void WallCollision(Collision2D collision)
    {
        Projectile projectileCollided = collision.gameObject.GetComponent<Projectile>();
        RubyController playerCollided = collision.gameObject.GetComponent<RubyController>();
        if (playerCollided == null && projectileCollided == null)
            bonk = true;
    }

    
    public void PhysicalMove()
    {
        if (!broken)
            return;

        Vector2 position = rigidbody2D.position;

        MovementPattern(bonk);

        AnimationMove();

        position.x = position.x + enemySpeed * Time.deltaTime * direction.x;
        position.y = position.y + enemySpeed * Time.deltaTime * direction.y;
        rigidbody2D.MovePosition(position);
        bonk = false;
    }

    public void AnimationMove()
    {
        animator.SetFloat("Move X", direction.x);
        animator.SetFloat("Move Y", direction.y);
    }

    public void Fix()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(fixClip);
        hitEffect.Play();
        smokeEffect.Stop();
        questManager.RobotFixed();
        broken = false;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
    }

    public abstract void MovementPattern(bool bonk);

}
