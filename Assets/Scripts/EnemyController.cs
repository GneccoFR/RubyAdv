using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private QuestManager questManager;
    public AudioClip bonkClip;
    public AudioClip fixClip;
    AudioSource audioSource;
    Rigidbody2D rigidbody2D;
    Animator animator;
    public ParticleSystem smokeEffect;
    public ParticleSystem hitEffect;

    public bool vertical;
    public float enemySpeed = 2.0f;
    public float changeTime = 3.0f;
    public int enemyDamage = 2;

    bool broken = true;
    float timer;
    int direction = 1;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        
        timer = changeTime;
        questManager = QuestManager.GetInstance();
    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
        if (!broken)
            return;

        DirectionTimer();

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + enemySpeed * Time.deltaTime * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + enemySpeed * Time.deltaTime * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
    }

    public void DirectionTimer()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Projectile projectileCollided = collision.gameObject.GetComponent<Projectile>();
        if (projectileCollided != null)
        {
            audioSource.PlayOneShot(bonkClip);
            Fix();
        }

        RubyController playerCollided = collision.gameObject.GetComponent<RubyController>();
        if (playerCollided != null)
        {
            audioSource.PlayOneShot(bonkClip);
            playerCollided.ChangeHealth(-enemyDamage);
        }
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
}
