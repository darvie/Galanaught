using UnityEngine;

public class GigaUP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"collided with{other.gameObject.name}");
        AudioManager.Instance.PlayPowerUpGigaSFX();
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().GigaPowerUp();
            Destroy(this.gameObject);
        }
    }
}
