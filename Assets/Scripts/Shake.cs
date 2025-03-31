using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour
{
    public static Shake Instance;

    public float shakeDuration = 0.5f;  // Duration of the shake
    public AnimationCurve shakeCurve;

    private Vector3 originalPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void StartShake()
    {
        StopAllCoroutines(); // Stop previous shakes if needed
        StartCoroutine(Shaking());
    }

    private IEnumerator Shaking()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            elapsedTime += Time.deltaTime;
            float strength = shakeCurve.Evaluate(elapsedTime / shakeDuration);
            transform.localPosition = originalPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.localPosition = originalPosition; // Reset position
    }
}