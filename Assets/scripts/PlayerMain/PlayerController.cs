using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    private Player playerInput;
    private CharacterController playerController;
    public Transform bulletPoint;

    

    public BulletBehavior bulletBehavior;


    private void Awake()
    {
       
        playerInput = new Player();
        playerController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();

    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public float MoveSpeed = 0f;


    private void Start()
    {
        InvokeRepeating("Fire", 0.1f, bulletBehavior.spawnTimer);
    }


    private void Update()
    {
        
        
        Vector2 moveInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector2 move = new(moveInput.x, moveInput.y);
        playerController.Move(MoveSpeed * Time.deltaTime * move);

        
    }

    private void Fire()
    {
        GameObject bullet = BulletPool.instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = bulletPoint.position;
            bullet.SetActive(true);
        }
    }

    


}
