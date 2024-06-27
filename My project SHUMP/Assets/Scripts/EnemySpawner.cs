using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float initialSpawnRate = 3.0f;
    public float spawnRateIncrease = 0.07f;
    public float minSpawnRate = 0.5f;
    private bool stopSpawning = false;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        float currentSpawnRate = initialSpawnRate;

        while (!stopSpawning)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; //randomly choose a spawn location
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(currentSpawnRate);

            if (currentSpawnRate > minSpawnRate)
            {
                currentSpawnRate -= spawnRateIncrease;
            }
        }
    }

    public void StopSpawning()
    {
        stopSpawning = true;
    }

}