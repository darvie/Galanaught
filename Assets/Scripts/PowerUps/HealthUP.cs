using UnityEngine;

public class HealthUP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"collided with{other.gameObject.name}");


        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayPowerUpInvulnerabilitySFX();

            other.gameObject.GetComponent<PlayerController>().HEALPOWERUP();
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
