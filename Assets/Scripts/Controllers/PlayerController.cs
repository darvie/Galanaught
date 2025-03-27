using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public int LifeCounter = 3;

    public float fireDelay = 0.1f;
    private float cooldownTimer = 0;

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

        if (LifeCounter <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player defeated!");
        Destroy(gameObject); // Destroy player when Lives reaches zero
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

}
