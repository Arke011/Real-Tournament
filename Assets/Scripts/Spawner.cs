using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    public List<Transform> spawnPoints;
    public List<int> enemiesPerWave;
    [Range(0.1f, 10f)]
    public float spawnInterval = 1f;
    [Range(0.1f, 10f)]
    public float timeBetweenWaves;

    public int enemiesToSpawn;

    public UnityEvent onWaveEnd;
    public UnityEvent onWaveStart;
    public UnityEvent onWavesCleared;
    
    async void Start()
    {
        onWaveStart.Invoke();

        foreach (var number in enemiesPerWave)
        {
            enemiesToSpawn = number;

            while (enemiesToSpawn > 0)
            {
                await new WaitForSeconds(spawnInterval);
                Spawn();
                enemiesToSpawn--;
            }

        }

        onWaveEnd.Invoke();
        await new WaitForSeconds(timeBetweenWaves);

        
        
    }

    onWavesCleared.Invoke();

    
    void Spawn()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        Instantiate(prefab, point.position, point.rotation);
    }
}
