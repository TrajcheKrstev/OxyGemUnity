using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public float life = 3f;
    public int maxHits = 25;
    public LayerMask hitLayer;
    public float explosiveForce;
    public float radius = 10f;
    public AudioSource explosionSound;

    public GameObject explosionEffect;

    private Collider[] hits;

    private void Awake()
    {
        hits = new Collider[maxHits];
        //Destroy(gameObject, life);
    }

    private void Start()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("explosion-sound");
        explosionSound = audioObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionEffect, gameObject.transform.position, Quaternion.identity);
        if (!explosionSound.isPlaying) explosionSound.Play();
        int hitNo = Physics.OverlapSphereNonAlloc(gameObject.transform.position, radius, hits, hitLayer);
        for(int i = 0; i < hitNo; i++)
        {
            if (hits[i].TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(explosiveForce, gameObject.transform.position, radius);
            }
        }
        Destroy(gameObject);
        Destroy(explosion, 0.5f);
    }
}
