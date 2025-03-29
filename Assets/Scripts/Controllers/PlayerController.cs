using UnityEngine;
using System.Collections;
using UnityEditor.ShaderGraph;
using System;
using System.Data;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public int LifeCounter = 3;

    public float fireDelay = 0.1f;
    private float cooldownTimer = 0;

    public GameObject bulletPrefab;

    [Header("Sprites")]
    public Sprite Death;
    public Sprite Damaged;
    public Sprite Norm;
    public Sprite Invuln;
    private SpriteRenderer SpriteRenderer;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnFire.AddListener(PlayerShoot);
        cooldownTimer -= Time.deltaTime;
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void MovePlayer(Vector2 direction)
    { 
        rb.linearVelocity = direction * speed;
    }

    public void LooseHP()
    {
        LifeCounter -= 1;
        Debug.Log("Player Hit!");
        if(LifeCounter == 2)
        {
            StateChange();
            Debug.Log("Changed to Damaged Sprite");

        }
        else if (LifeCounter <= 0)
        {
            Die();
            Debug.Log("Changed to Death Sprite");
        }
        else
        {
            SpriteRenderer.sprite = Norm;
        }
    }

    void Die()
    {
        Debug.Log("Player defeated!");
        StateChange();
        Destroy(gameObject, 1f); // Destroy player when Lives reaches zero
    }

    private void PlayerShoot()
    {
        if (cooldownTimer <= 0)
        {
            Vector3 offset = new Vector3(0, 1f, 0);

            Debug.Log("Pew!");
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

            cooldownTimer = fireDelay; // Reset the cooldown timer
            Debug.Log("Cooldown reset to: " + cooldownTimer);
        }
    }

    public void StateChange()
    {
        if (LifeCounter == 2)
        {
            SpriteRenderer.sprite = Damaged;

        }
        else if (LifeCounter <= 0)
        {
            SpriteRenderer.sprite = Damaged;
        }
        else
        {
            SpriteRenderer.sprite = Norm;
        }

    }
}
