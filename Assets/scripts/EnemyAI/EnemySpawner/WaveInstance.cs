using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveInstance : MonoBehaviour
{



    public GameObject enemyPrefab;

    [Tooltip("Number of enemies in the wave")]
    public int count; //number of time the enemy spawns in a single wave
    public float timeBetweenSpawns;

    [Tooltip("When to initiate the wave")]
    public float timeToSpawn;
    

}
