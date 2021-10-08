using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    
    public float timeWaves = 5f;
    private float _countdown = 3f;

    public Text waveCountdown;
    
    private int _waveNumber = 0;
    
    void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeWaves;
        }
        _countdown -= Time.deltaTime;
        waveCountdown.text = "Next Wave in " + Mathf.Round(_countdown).ToString() + " seconds";
    }

    IEnumerator SpawnWave()
    {
        _waveNumber++;
        
        for (int i = 0; i < _waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.3f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}