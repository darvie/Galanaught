using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float MinSpawnTimer;
    [SerializeField] private float MaxSpawnTimer;
    private float TimetilSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetSpawnTime();
        
    }

    // Update is called once per frame
    void Update()
    {
        TimetilSpawn -= Time.deltaTime;

        if( TimetilSpawn <= 0)
        {
            Instantiate( _enemyPrefab , transform.position, Quaternion.identity);
            SetSpawnTime();

        }
    }

    private void SetSpawnTime()
    {
        TimetilSpawn = Random.Range(MinSpawnTimer, MaxSpawnTimer);
    }
}
