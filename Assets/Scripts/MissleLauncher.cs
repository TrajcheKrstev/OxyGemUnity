using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleLauncher : MonoBehaviour
{
    public Transform missleSpawnPoint;
    public GameObject misslePrefab;
    public float missleSpeed;
    public AudioSource missleLaunchSound;
    private PauseMenuScript pauseMenuScript;

    private void Start()
    {
        pauseMenuScript = FindObjectOfType<PauseMenuScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenuScript.isPaused && Input.GetMouseButtonDown(0) && !missleLaunchSound.isPlaying)
        {
            missleLaunchSound.Play();
            var missle = Instantiate(misslePrefab, missleSpawnPoint.position, missleSpawnPoint.rotation);
            missle.GetComponent<Rigidbody>().velocity = missleSpawnPoint.forward * missleSpeed;
        }
    }
}
