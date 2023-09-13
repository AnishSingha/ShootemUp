using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{

    [SerializeField] public bool isShooting ;
    [SerializeField] public float firerate ;

    private void Start()
    {
        StartCoroutine(EShoot());
    }


    public IEnumerator EShoot()
    {
        while (isShooting == true)
        {
            GameObject bullet = TurretBulletPool.instance.GetPooledObject();
            //GameObject gameObjectInScene = GameObject.Find("Player");
            if (bullet != null)
            {
                bullet.transform.position = transform.position; 
                bullet.transform.localRotation = transform.rotation;
                yield return new WaitForSeconds(0.01f);
                bullet.SetActive(true);

            }


            else
            //if (gameObjectInScene==null)
            {
                break;
            }
            yield return new WaitForSeconds(firerate);
        }
    }
}
