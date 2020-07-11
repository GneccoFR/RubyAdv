using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RubyController : MonoBehaviour
{
    public AudioClip hitClip;
    public AudioClip throwingClip;
    public Joystick mobileJoystick;
    public LevelManager levelManager;
    public TextMeshProUGUI ammoDisplay;
    AudioSource audioSource;
    Animator animator;
    Rigidbody2D rigidbody2D;
    public ParticleSystem pickUpEffect;
    public GameObject projectilePrefab;

    Vector2 lookDirection = new Vector2(1, 0);
    float horizontal;
    float vertical;
    public float speed = 3f;

    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    bool alive;

    public int currentAmmo;
    public int maxAmmo;

    void Start()
    {
        maxAmmo = 5;
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        alive = true;
    }

    void Update()
    {
        if (!alive) return;

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

#else

        horizontal = mobileJoystick.Horizontal;
        vertical = mobileJoystick.Vertical;

#endif        
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
            Launch();

        if (Input.GetKeyDown(KeyCode.X))
            attemptToInteract();

        if (Input.GetKeyDown(KeyCode.Escape))
            levelManager.PauseGame();

        if (Input.GetKeyDown(KeyCode.H))
            levelManager.OnOffInstructions();
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2D.MovePosition(position);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void Launch()
    {
        if (currentAmmo > 0)
        {
            GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2D.position + Vector2.up * 0.3f, Quaternion.identity);
            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch(lookDirection, 300);
            animator.SetTrigger("Launch");
            PlaySound(throwingClip);
            currentAmmo -= 1;
            RecountAmmo();
        }
    }

    public void attemptToInteract()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position + Vector2.up * 0.3f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
            if (character != null)
                character.Interact();
        }
    }

    public void ChangeHealth (int amount)
    {
        if (amount < 0)
        { 
            animator.SetTrigger("Hit");
            if (isInvincible)
                return;
            PlaySound(hitClip);
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        else
            pickUpEffect.Play();
            
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        if (currentHealth <= 0) Die();
    }

    public void RecountAmmo()
    {
        ammoDisplay.text = "= " + currentAmmo + "/" + maxAmmo;
    }

    public void Die()
    {
        alive = false;
        horizontal = 0;
        vertical = 0;
        levelManager.Lose();
    }
}