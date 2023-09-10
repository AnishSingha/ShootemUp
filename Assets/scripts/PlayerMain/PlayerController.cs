using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour 
{
    private Player playerInput;
    private CharacterController playerController;
    public Transform bulletPoint;
    public BulletBehavior bulletBehavior;
    public Camera mainCamera;
    public GameObject joyStick;

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

        Input.gyro.enabled = true;
        InvokeRepeating("Fire", 0.1f, bulletBehavior.spawnTimer);
        
    }

    #region GyroImplementation

     
    float dirX;
    float dirY;
    public float MoveSpeedGyro = 20f;
    public bool isGyroEnabled = false;


    #endregion

    public void GyroMove()
    {
        dirX = Input.gyro.gravity.x;
        dirY = Input.gyro.gravity.y;

        // Move the character based on the gyroscope input.
        Vector3 moveDirectionX = new Vector3(dirX, 0f, 0f);
        Vector3 moveDirectionY = new Vector3(0f, dirY, 0f);

        moveDirectionX *= MoveSpeedGyro * Time.deltaTime;
        moveDirectionY *= MoveSpeedGyro * Time.deltaTime;

        playerController.Move(moveDirectionX);
        playerController.Move(moveDirectionY);
    }

    private void Update()
    {
        

        if (isGyroEnabled == true)
        {
            GyroMove();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                // Enable the object when you touch the screen.
                joyStick.SetActive(true);
                Vector3 touchPosition = touch.position;
                
                touchPosition = mainCamera.ScreenToWorldPoint(touchPosition);
                joyStick.transform.localPosition = new Vector3(touchPosition.x, touchPosition.y , touchPosition.z);

                //movement Logic
                Vector2 moveInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
                Vector2 move = new(moveInput.x, moveInput.y);
                playerController.Move(MoveSpeed * Time.deltaTime * move);
            }
        }
        else
        {
            joyStick.SetActive(false);
        }

       /* if (Input.GetMouseButton(0))
        {
            joyStick.SetActive(true);
            Vector2 clickPos = m
        }
       */


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
