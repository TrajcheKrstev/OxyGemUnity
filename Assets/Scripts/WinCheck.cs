using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    GemCollector gemCollector;
    MeshCollider meshCollider;
    public int totalGems = 4;

    private void Awake()
    {
        gemCollector = FindObjectOfType<GemCollector>();
        meshCollider = GetComponent<MeshCollider>();
    }

    private void Update()
    {
        if(gemCollector.nGemsCollected == totalGems)
        {
            meshCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
