using UnityEngine;

public class BulletStats : MonoBehaviour
{
    [Header("Scripts")]
    public EnemyStats EnemyStats;

    [Header("Stats")]
    public float damage = 10f;
    public void IncreaseDamage(float amount)
    {
        damage += amount;
        Debug.Log($"Bullet damage increased: {damage}");
    }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {

        Destroy(gameObject, 5f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"collided with{other.gameObject.name}");
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<PlayerController>().LooseHP();
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
