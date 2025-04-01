using UnityEngine;

public class InvulnUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"collided with{other.gameObject.name}");
        AudioManager.Instance.PlayPowerUpInvulnerabilitySFX();
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().InvulnPowerUp();
            Destroy(this.gameObject);
        }
    }
}
