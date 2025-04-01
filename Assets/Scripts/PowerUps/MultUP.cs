using UnityEngine;

public class MultUP : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log($"collided with{other.gameObject.name}");

        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayPowerUpMultiShotSFX();

            other.gameObject.GetComponent<PlayerController>().MultiPowerUp();
            Destroy(this.gameObject);
        }
    }
}
