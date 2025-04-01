using UnityEngine;

public class MultUP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"collided with{other.gameObject.name}");
        AudioManager.Instance.PlayPowerUpMultiShotSFX();

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().MultiPowerUp();
            Destroy(this.gameObject);
        }
    }
}
