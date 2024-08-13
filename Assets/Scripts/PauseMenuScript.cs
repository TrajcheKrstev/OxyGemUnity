using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public Slider masterVolume;
    public AudioSource lowOxygenSound;
    public AudioSource radarSound;
    public AudioSource underwaterSound;



    void Start()
    {
        pauseMenu.SetActive(false);
        masterVolume.value = AudioListener.volume;
        AudioManager.Instance.ChangeMasterVolume(masterVolume.value);
        masterVolume.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMasterVolume(val));
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ContinueGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        if(lowOxygenSound.isPlaying) lowOxygenSound.Pause();
        radarSound.Pause();
        underwaterSound.Pause();
        Cursor.lockState = CursorLockMode.None;
    }
    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        lowOxygenSound.Play();
        radarSound.Play();
        underwaterSound.Play();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
