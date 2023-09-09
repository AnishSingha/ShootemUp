using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    public BulletBehavior bulletBehavior;

    [SerializeField] private Rigidbody rb;


    private void FixedUpdate()
    {
        rb.velocity = Vector3.left * bulletBehavior.bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("EnemyWall"))
        {
            gameObject.SetActive(false);
        }

    }
}
