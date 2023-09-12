using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> bulletPrefabs;
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private float bulletSpeed = 10.0f;
    [SerializeField] private List<float> spawnAngles;

    private float nextFireTime = 0.0f;

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1 / fireRate;
            SpawnBullets();
        }
    }

    private void SpawnBullets()
    {
        foreach (var angle in spawnAngles)
        {
            Vector3 bulletDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
            foreach (var bulletPrefab in bulletPrefabs)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = bulletDirection * bulletSpeed;
            }
        }
    }
}