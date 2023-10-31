using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{

    [Header("Please assign the transform values of the enemyspawner \n" +
        "to the prefab of spline(It is mandatary to do so)")]

    [Space]
    [SerializeField] WaveInstance waveInstance1;




    IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(waveInstance1.timeToSpawn);


        for (int i = 0; i < waveInstance1.count; i++)
        {
            SpawnEnemy(waveInstance1.enemyPrefab);
            yield return new WaitForSeconds(waveInstance1.timeBetweenSpawns);
        }

        Debug.Log("RoundCompleted");
    
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 spawnPos = transform.position;
        Instantiate(enemyPrefab, spawnPos , Quaternion.identity);
    }

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }


}
