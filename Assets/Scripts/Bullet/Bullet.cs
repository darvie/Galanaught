using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Ball Movement")]
    [SerializeField] private float bulletLaunchSpeed;

    [Header("References")]
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Rigidbody rb;

    public AudioManager Audiomanager;

    private bool isBallActive;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Environment"))
        {
            if (Audiomanager != null)
            {
                Audiomanager.PlayExplosionSFX();
            }
        }
        if (other.gameObject.CompareTag("Paddle"))
        {
            Vector3 directionToFire = (transform.position - other.transform.position).normalized;
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            
            if (Audiomanager != null)
            {
                Audiomanager.PlayExplosionSFX();
            }
        }
    }



    public void FireBullet()
    {
        if (isBallActive) return;
        transform.parent = null;
        rb.isKinematic = false;
        rb.AddForce(transform.forward * bulletLaunchSpeed, ForceMode.Impulse);
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        isBallActive = true;
    }
}
