using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Pool;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem.OnScreen;

public class PlayerController : MonoBehaviour 
{
    private Player playerInput;
    private CharacterController playerController;
    public Transform bulletPoint;
    public BulletBehavior bulletBehavior;
    public Camera mainCamera;
    public GameObject joyStick;
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] GameObject stick;

    float screenWidth;
    float screenHeight;

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
        screenWidth = Screen.width;
        //Debug.Log(screenWidth);
        screenHeight = Screen.height;
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
        Vector2 moveInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector2 move = new(moveInput.x, moveInput.y);
        playerController.Move(MoveSpeed * Time.deltaTime * move);

        if (isGyroEnabled == true)
        {
            GyroMove();
        }



        int touchcount = Input.touchCount;
       // Debug.Log(touchcount);


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Debug.Log(touch.phase);
            Vector3 touchPosition = touch.position;
            

            if (touch.phase == TouchPhase.Began)
            {
              
                
                image1.color = new Vector4(256f, 256f, 256f, 1f);
                image2.color = new Vector4(256f, 256f, 256f, 1f);

                joyStick.transform.localPosition = new Vector3(touchPosition.x - (screenWidth / 2), touchPosition.y - (screenHeight / 2), touchPosition.z);

                stick.transform.localPosition = new Vector3(touchPosition.x - (screenWidth / 2), touchPosition.y - (screenHeight / 2), touchPosition.z);
                // Enable the object when you touch the screen.
                //joyStick.SetActive(true);



                //Debug.Log(touchPosition);

                // touchPosition = mainCamera.ScreenToWorldPoint(touchPosition); 





            }
            /*          if (touch.phase == TouchPhase.Moved)
                      {
                          var delta = stick.transform.position - touchPosition;
                          delta = Vector2.ClampMagnitude(delta, 10f);
                          Debug.Log(delta);
                          var newPos = new Vector3(delta.x / 10f, delta.y / 10f);

                          stick.transform.localPosition = new Vector3(newPos.x - (screenWidth / 2), newPos.y - (screenHeight / 2), newPos.z);
                      }*/
        }
        else
        {
            //joyStick.SetActive(false);
            image1.color = new Vector4(0,0,0,0);
            image2.color = new Vector4(0,0,0,0);
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
