using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Slider masterVolume;

    private void Start()
    {
        masterVolume.value = AudioListener.volume;
        AudioManager.Instance.ChangeMasterVolume(masterVolume.value);
        masterVolume.onValueChanged.AddListener(val => AudioManager.Instance.ChangeMasterVolume(val));
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game.");
    }
}
