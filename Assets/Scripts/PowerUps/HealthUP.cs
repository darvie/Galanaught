using UnityEngine;

public class HealthUP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"collided with{other.gameObject.name}");

        AudioManager.Instance.PlayPowerUpInvulnerabilitySFX();

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().HEALPOWERUP();
            Destroy(this.gameObject);
        }
    }
}
