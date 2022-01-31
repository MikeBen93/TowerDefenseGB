using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveCountdownText;

    public float timeBetweenWaves = 4f;
    private float _countdown = 2f;

    private int _waveIndex = 0;

    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", _countdown);
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++;
        PlayerStats.Rounds++;
        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        
        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, transform.rotation);
    }

}
