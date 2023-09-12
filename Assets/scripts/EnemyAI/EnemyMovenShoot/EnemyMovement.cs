using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyMovement : MonoBehaviour , IDamageable
{

    //[SerializeField] GameObject E_bullet;
    [Header("This Script requires a player to be present in the scene with its tag.")]
    [Space]

    public Transform bulletPos;

    [Header("This takes reference to the Instance of EObjectVar")]
    [Space]
    [Tooltip("Create a scriptable object of enemyInstanceValues and attach it to this")]
    public EObjectVar e_values;
    float currentHealth;



    private void Start()
    {
        
        currentHealth = e_values.e_health;
        StartCoroutine(EShoot());
        

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
            //GameObject gameObjectInScene = GameObject.Find("Player");
            if (bullet != null)
            {
                bullet.transform.position = bulletPos.position;
                bullet.SetActive(true);
                
            }


            else
            //if (gameObjectInScene==null)
            {
                break;
            }
            yield return new WaitForSeconds(e_values.e_Firerate);
        }    
    }
}
