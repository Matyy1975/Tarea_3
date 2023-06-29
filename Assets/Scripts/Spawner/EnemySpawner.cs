using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
}

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnData[] enemiesToSpawn; // Datos de enemigos a invocar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Invocar enemigos según los datos de spawn
            foreach (EnemySpawnData spawnData in enemiesToSpawn)
            {
                Instantiate(spawnData.enemyPrefab, spawnData.spawnPoint.position, spawnData.spawnPoint.rotation);
            }

            // Destruir este objeto de spawner
            Destroy(gameObject);
        }
    }
}
