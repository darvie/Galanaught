using UnityEngine;

public class BFG : MonoBehaviour
{
    public float bulletLife = 1f;  // Defines how long before the bullet is destroyed
    public float rotation = 0f;
    public float speed = 1f;

    private Vector2 spawnPoint;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);

    }

    private Vector2 Movement(float timer)
    {
        // Moves right according to the bullet's rotation
        // float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.up.y;
        return new Vector2(spawnPoint.x, y + spawnPoint.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"BFG collided with{other.gameObject.name}");
        if (other.gameObject.CompareTag("Enemy"))
        {

            other.gameObject.GetComponent<EnemyStats>().TakeDamage(3000);
            Destroy(gameObject);
            AudioManager.Instance.PlayExplosionSFX();
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
