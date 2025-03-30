using UnityEngine;

public class InvulnUP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"collided with{other.gameObject.name}");
        if (other.gameObject.CompareTag("Player"))
        {
        other.gameObject.GetComponent<PlayerController>().InvulPowerUp();
            Destroy(this.gameObject);
        }
    }
}
