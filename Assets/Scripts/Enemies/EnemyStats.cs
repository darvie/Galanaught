using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float enemyHealth = 100f;   // Initial health of the enemy
    public float enemyDamage = 10f;    // Initial damage of the enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseStats(float healthIncrease, float damageIncrease)
    {
        enemyHealth += healthIncrease;
        enemyDamage += damageIncrease;
        Debug.Log($"Enemy stats updated: Health = {enemyHealth}, Damage = {enemyDamage}");
    }

    public void movement()
    {

    }

    public void OnCollision()
    {

    }
}
