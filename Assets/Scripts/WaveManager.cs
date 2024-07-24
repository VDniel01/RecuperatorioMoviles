using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerUpPrefabs; // Asigna aquí tus prefabs de power-ups
    public Transform[] spawnPoints;
    public int waveNumber = 0;
    private int enemiesToSpawn;

    void Start()
    {
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

        // Decidir aleatoriamente si spawnear un power-up
        if (Random.value < 0.2f) // 20% de probabilidad de spawn de power-up
        {
            int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);
            Instantiate(powerUpPrefabs[powerUpIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
}