using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public Light spotlight;
    InputManager inputManager;
    PlayerMovement playerMovement;
    CameraManager cameraManager;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        cameraManager = FindAnyObjectByType<CameraManager>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void ToggleSpotlight()
    {
        if (spotlight != null && Input.GetKeyDown(KeyCode.R))
        {
            spotlight.enabled = !spotlight.enabled;
        }
    }

    private void Update()
    {
        inputManager.HandleAllInput();

        ToggleSpotlight();
    }

    private void FixedUpdate()
    {
        playerMovement.HandleAllMovement();
    }

    private void LateUpdate()
    {
       
       cameraManager.HandleAllCameraMovement();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("mine"))
        {
            // Handle the collision with the mine object
            Debug.Log("Player collided with a mine!");
            Invoke("GameOver", 1f);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
