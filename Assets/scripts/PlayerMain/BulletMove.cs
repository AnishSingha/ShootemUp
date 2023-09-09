using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    public BulletBehavior bulletBehavior;

    [SerializeField] private Rigidbody rb;


    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * bulletBehavior.bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") ||  other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }

    }
}
