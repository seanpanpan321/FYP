using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor playerMotor;
    private PlayerLook playerLook;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = this.playerInput.OnFoot;

        playerMotor = GetComponent<PlayerMotor>();
        playerLook = GetComponent<PlayerLook>();

        //add the playerMotor jump callback funtion to jump action 
        onFoot.Jump.performed += ctx => playerMotor.jump();
    }

    private void FixedUpdate()
    {
        playerMotor.ProcessMove(this.onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.ProcessLook(this.onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        this.onFoot.Enable();
    }

    private void OnDisable()
    {
        this.onFoot.Disable();
    }
}
