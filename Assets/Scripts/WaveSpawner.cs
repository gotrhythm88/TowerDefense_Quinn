using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform enemyPrefab;
    public Text waveCountdown;

    public float countdown = 3f;
    public float timeBetweenWaves = 5f;
    private int waveNumber = 0;


    void Update(){
        countdown -= Time.deltaTime;
        waveCountdown.text = Mathf.Round(countdown).ToString();

        if(countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            timeBetweenWaves += 0.5f;
        }
    }

    IEnumerator SpawnWave(){
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
