using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAimBullet : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        
        Debug.DrawRay(transform.position, Vector3.up, Color.red);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;

        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.eulerAngles = Vector3.forward * angle; 

    }
}
