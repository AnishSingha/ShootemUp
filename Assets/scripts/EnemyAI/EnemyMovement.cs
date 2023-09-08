using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour , IDamageable
{
    [SerializeField] Rigidbody rb;
    //[SerializeField] GameObject E_bullet;

    public Transform bulletPos;
    public EObjectVar e_values;
    float currentHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = e_values.e_health;
        StartCoroutine(EShoot());
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(e_values.e_xAxis,e_values.e_yAxis,e_values.e_zAxis) * e_values.e_moveSpeed * Time.deltaTime;
        
    }
    void Update()
    {
        if (currentHealth<= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            float damage = e_values.e_takeDamage;
            TakeDamage(damage);
        }

        
    }
    public IEnumerator EShoot()
    {
        while (e_values.isShooting == true)
        {
            GameObject bullet = EnemyBulletPool.instance.GetPooledObject();

            if (bullet != null)
            {
                bullet.transform.position = bulletPos.position;
                bullet.SetActive(true);
                yield return new WaitForSeconds(e_values.e_Firerate);
            }
        }

    }
       

    
}
