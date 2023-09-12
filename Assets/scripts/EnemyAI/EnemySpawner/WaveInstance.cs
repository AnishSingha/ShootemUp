using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "WaveInstance", menuName = "ScriptableObjects/WaveValues", order = 1)]
[Serializable]
public class WaveInstance : ScriptableObject
{
    [SerializeField] public GameObject enemyPrefab;

    [Tooltip("Number of enemies in the wave")]
    [SerializeField] public int count; //number of time the enemy spawns in a single wave
    [SerializeField] public float timeBetweenSpawns;

    [Tooltip("When to initiate the wave")]
    [SerializeField] public float timeToSpawn;



}
