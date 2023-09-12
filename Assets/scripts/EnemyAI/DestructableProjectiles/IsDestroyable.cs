using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDestroyable : MonoBehaviour , IDamageable
{
    [SerializeField] public float maxHealth;
    [SerializeField] float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1f);
        }
    }

    private void Update()
    {
        if (currentHealth <=0) 
        {
            Destroy(gameObject);
        }
    }
}
