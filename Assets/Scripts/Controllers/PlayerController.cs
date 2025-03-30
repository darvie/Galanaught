using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Rigidbody2D rb;

    public GameObject gameOverPanel;
    public AudioManager AudioManager;

    [Header("Player Stats")]
    [SerializeField] private float speed;
    [SerializeField] public int LifeCounter = 3;
    public float fireDelay = 0.1f;
    private float cooldownTimer = 0;

    [Header("Sprites")]
    public Sprite Damaged;
    public Sprite Dead;

    [Header("Invuln Shield")]
    public GameObject Shield;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    void Start()
    {
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
        if (LifeCounter == 2)
        {
            StartCoroutine(Invuln());
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Damaged;
            Debug.Log("DAMAGE SPRITE!");

        }
        else if (LifeCounter <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Dead;
            Debug.Log("DEATH SPRITE!");
            Die();
        }
    }

    IEnumerator Invuln()
    {
        Shield.SetActive(true);
        Physics2D.IgnoreLayerCollision(0,6,true);
        Debug.Log("I AM GOD!");
        yield return new WaitForSeconds(2);
        Physics2D.IgnoreLayerCollision(0, 6, false);
        Shield.SetActive(false);
        

    }

    void Die()
    {
        Debug.Log("Player defeated!");
        this.gameObject.GetComponent<PlayerController>().enabled = false;
        Destroy(gameObject,3f); // Destroy player when Lives reaches zero
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

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
            AudioManager.PlayLaserBulletSFX();
        }
    }

}
