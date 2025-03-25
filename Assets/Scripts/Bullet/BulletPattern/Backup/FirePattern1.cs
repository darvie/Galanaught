using UnityEngine;

public class FirePattern1 : MonoBehaviour
{
    public float angle = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        InvokeRepeating("Fire", 0f, 0.1f);
        
    }
    private void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI)/180f);
        float bulDirY = transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

       
        GameObject bul = BulletPool.BulletPoolInstance.GetBullet();
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<EnemyBullet>().SetMoveDirection(bulDir);
       
        angle += 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
