using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MissileInstance", menuName = "ScriptableObjects/MissileValues", order = 1)]
public class HomingMissile : ScriptableObject
{

    [Header("Missile values")]
    [SerializeField] public float speed;


    [Tooltip("Speed at which the missile rotates towards its target. 0.2 or 0.3 is a good speed to assign")]
    [SerializeField] public float rotateSpeed;

}
