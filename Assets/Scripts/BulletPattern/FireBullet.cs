using UnityEngine;
using UnityEngine.Rendering;

public class FireBullet : MonoBehaviour
{
    [Header("Ammount")]
    [SerializeField] public int bulletsAmount = 10;

    [Header("Angle")]
    [SerializeField] public float startAngle = 90f;
    [SerializeField] public float endAngle = 270f;

    private Vector2 bulletMoveDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
        
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletsAmount; i++) {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.x + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

           
             GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
             bul.transform.position = transform.position;
             bul.transform.rotation = transform.rotation;
             bul.SetActive(true);
             bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            
            angle += 10f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
