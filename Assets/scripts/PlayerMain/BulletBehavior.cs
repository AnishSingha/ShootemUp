using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletInstance", menuName = "ScriptableObjects/BulletScriptableObject", order = 1)]
public class BulletBehavior : ScriptableObject
{
    public GameObject bulletPrefab; // used in BulletPool to give the appropriate gameobject to instantiate

    public float bulletSpeed;// speed of bullet in BulletMove

    public float spawnTimer; // used in PlayerController to give spawn rate timing

}

