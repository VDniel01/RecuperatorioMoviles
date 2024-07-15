using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public int waveNumber = 0;
    private int enemiesToSpawn;
    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
        StartNextWave();
    }

    void StartNextWave()
    {
        waveNumber++;
        enemiesToSpawn = waveNumber * 5; // Incrementa la dificultad
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f); // Intervalo entre enemigos
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
        // Alternativamente, usa el pool de objetos si ya está configurado
        // GameObject enemy = objectPooler.GetPooledObject();
        // if (enemy != null)
        // {
        //     enemy.transform.position = spawnPoints[spawnIndex].position;
        //     enemy.transform.rotation = Quaternion.identity;
        //     enemy.SetActive(true);
        // }
    }
}