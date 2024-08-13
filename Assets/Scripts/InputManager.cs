using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //PlayerControls playerControls;

    //public Vector2 movementInput;
    //public Vector2 cameraInput;

    //public float cameraInputX;
    //public float cameraInputY;

    //public float verticalInput;
    //public float horizontalInput;

    //private void OnEnable()
    //{
    //    if(playerControls == null)
    //    {
    //        playerControls = new PlayerControls();
    //        playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
    //        playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
    //    }
    //    playerControls.Enable();
    //}

    //private void OnDisable()
    //{
    //    playerControls.Disable();
    //}

    //private void HandleMovementInput()
    //{
    //    horizontalInput = movementInput.x;
    //    verticalInput = movementInput.y;

    //    cameraInputX = cameraInput.x;
    //    cameraInputY = cameraInput.y;
    //}

    //public void HandleAllInput()
    //{
    //    HandleMovementInput();
    //}

    PlayerControls playerControls;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float verticalInput;
    public float horizontalInput;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void HandleMovementInput()
    {
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;
    }

    public void HandleAllInput()
    {
        HandleMovementInput();
    }
}
