using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float timer = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"collided with{other.gameObject.name}");
        if (other.gameObject.CompareTag("Enemy"))
        {

            other.gameObject.GetComponent<EnemyStats>().TakeDamage(10);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall")){
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;

        transform.position = pos;

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
