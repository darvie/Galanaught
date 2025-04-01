using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float TotalHP = 0f;
    public float HealthInc = 10f;

    [Header("Timer Incriments")]
    public float incrementInterval = 10f;  // Time interval to increment stats (1 minute)
    public float Counter;

    public void Update()
    {
        Counter += Time.deltaTime;

        if (Counter >= incrementInterval)
        {

            UpdateMaxHP();
            Counter = 0f;
        }
    }

    public void UpdateMaxHP()
    {
        TotalHP += HealthInc;
        Debug.Log($"Enemy stats updated: Health = {TotalHP}");

    }
}