using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[Serializable]
[CreateAssetMenu(fileName = "EnemyInstance", menuName = "ScriptableObjects/EnemyInstanceValues", order = 1)]
public class EObjectVar : ScriptableObject
{
    [SerializeField] public float e_moveSpeed;
    [SerializeField] public float e_takeDamage;
    [SerializeField] public bool isShooting;
    [SerializeField] public float e_health;
    [SerializeField] public bool isMoving;
    [SerializeField] public float e_Firerate;

    // public Transform e_BulletPoint;
    //[SerializeField] GameObject e_prefab;

}
