using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TurretBulletMove : MonoBehaviour
{
    public BulletBehavior bulletBehavior;

    //[SerializeField] public Transform turretPoint;
    [SerializeField] private Rigidbody rb;


    private void FixedUpdate()
    {
        

        transform.Translate( Vector3.up * 10f *Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("EnemyWall"))
        {
            gameObject.SetActive(false);
        }

    }
}
