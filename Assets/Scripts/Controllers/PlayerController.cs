using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;

    private Rigidbody rb;
    public float fireDelay = 0.1f;
    float cooldownTimer = 0;

    public GameObject bulletPrefab;
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnFire.AddListener(PlayerShoot);
        cooldownTimer -= Time.deltaTime;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime; // Decrement cooldown timer here
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector2 moveDirection = new(direction.x, direction.y);
        rb.AddForce(speed * moveDirection);
    }

    private void PlayerShoot()
    {
        if (cooldownTimer <= 0)
        {
            Vector3 offset = new Vector3(0, 0.5f, 0);

            Debug.Log("Pew!");
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

            cooldownTimer = fireDelay; // Reset the cooldown timer
            Debug.Log("Cooldown reset to: " + cooldownTimer);
        }
    }

}
