using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    public GameObject explosion;
    public AudioSource explosionSound;

    private void Start()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("explosion-sound-2");
        explosionSound = audioObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Invoke("ExecuteCollision", 0.5f);
        Debug.Log("Collision detected");
    }


    void ExecuteCollision()
    {
        GameObject m = Instantiate(explosion, transform.position, transform.rotation);
        if (!explosionSound.isPlaying) explosionSound.Play();
        Destroy(m, 0.5f);
        Destroy(transform.parent.gameObject);
    }
}
