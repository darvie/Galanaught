using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public float damage = 10f;
    public void IncreaseDamage(float amount)
    {
        damage += amount;
        Debug.Log($"Bullet damage increased: {damage}");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
