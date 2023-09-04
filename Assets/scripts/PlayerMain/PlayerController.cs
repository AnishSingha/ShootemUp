using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player playerInput;

    private CharacterController playerController;

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

    private void Update()
    {
        Vector2 moveInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector2 move = new(moveInput.x, moveInput.y);
        playerController.Move(move * Time.deltaTime * MoveSpeed);    
        
    }










}
