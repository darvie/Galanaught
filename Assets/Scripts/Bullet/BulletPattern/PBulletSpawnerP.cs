using UnityEngine;

public class PBulletSpawnerP : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin)
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 1f);
        Debug.Log("Spawner Rotation: " + transform.rotation.eulerAngles);
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }

    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, transform.position, transform.rotation);
            Debug.Log("Bullet Spawned at Position: " + spawnedBullet.transform.position);
            Debug.Log("Bullet Rotation: " + spawnedBullet.transform.rotation.eulerAngles);

            spawnedBullet.GetComponent<EBulletNoPlayer>().speed = speed;
            spawnedBullet.GetComponent<EBulletNoPlayer>().bulletLife = bulletLife;
        }
    }
}
