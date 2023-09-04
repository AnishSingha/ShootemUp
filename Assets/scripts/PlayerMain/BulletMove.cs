using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    public BulletBehavior bulletBehavior;

    [SerializeField] private Rigidbody2D rb;


    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * bulletBehavior.bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }

}
