using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MissileMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private float startTime = 0f;


    [Header("Instance and target to follow")]
    [Tooltip("Attach the scriptable object instance that is created for assigning values of speed and rotation")]
    public HomingMissile homingMissile;
    [SerializeField] public Transform target;


    [Header("End Chase time")]
    [Tooltip("Time in seconds after which the missile will stop following its target/player")]
    public float StopfollowingAfter = 2f;


    private void Start()
    {

        startTime = Time.time;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction;
        if (Time.time - startTime <= StopfollowingAfter)
        {
            direction = target.position - rb.position;

            direction.Normalize();

            Vector3 amountToRotate = Vector3.Cross(direction, transform.forward) * Vector3.Angle(transform.forward, direction);

            rb.angularVelocity = -amountToRotate * homingMissile.rotateSpeed;
        }

        else
        {
            direction = transform.forward;
            rb.angularVelocity = Vector3.zero;
        }

        rb.velocity = direction * homingMissile.speed;
    }

}
