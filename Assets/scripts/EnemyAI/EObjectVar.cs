using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInstance", menuName = "ScriptableObjects/EnemyInstanceValues", order = 1)]
public class EObjectVar : ScriptableObject
{
    public float e_moveSpeed;
    public float e_xAxis;
    public float e_yAxis;
    public float e_zAxis;
    public float e_takeDamage;
    public bool isShooting;
    public float e_health;
    public bool isMoving;
   // public GameObject e_prefab;
    public float e_Firerate;
    // public Transform e_BulletPoint;


}
