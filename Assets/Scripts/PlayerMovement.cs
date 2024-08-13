using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    Transform cameraObject;
    Rigidbody playerRigidBody;
    public Animator propellerAnimator;
    public AudioSource propellerSound;

    public float moveSpeed = 7;
    public float rotationSpeed = 15;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerRigidBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    private void HandleMovement()
    {
        if (inputManager.verticalInput > 0)
        {
            propellerAnimator.SetBool("start_rotation", true);
        }
        else
        {
            propellerAnimator.SetBool("start_rotation", false);
        }

        if (inputManager.verticalInput < 0)
        {
            propellerAnimator.SetBool("start_rotation_backward", true);
        }
        else
        {
            propellerAnimator.SetBool("start_rotation_backward", false);
        }

        if (inputManager.verticalInput != 0 && !propellerSound.isPlaying)
        {
            propellerSound.Play();
        }
        else if (inputManager.verticalInput == 0 && propellerSound.isPlaying)
        {
            propellerSound.Stop();
        }

        bool spacePressed = Input.GetKey(KeyCode.Space);
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

        Vector3 moveDirection = new Vector3(inputManager.horizontalInput, spacePressed ? 1f : (shiftPressed ? -1f : 0f), inputManager.verticalInput).normalized;
        moveDirection = transform.TransformDirection(moveDirection);  // Transform local to world space


        moveDirection.Normalize();
        moveDirection *= moveSpeed;

        Vector3 movementVelocity = moveDirection;
        playerRigidBody.velocity = movementVelocity;

        float rotationSpeed = 2f;  // Adjust this value to control rotation speed
        transform.Rotate(Vector3.up, inputManager.horizontalInput * rotationSpeed);
    }

    public void HandleAllMovement()
    {
        HandleMovement();
    }
}
