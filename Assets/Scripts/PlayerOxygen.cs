using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerOxygen : MonoBehaviour
{
    public float oxygenAmount = 240f;
    public float currentOxygen;
    public AudioSource bubbleCollectSound;
    public Slider oxygenSlider;

    // Start is called before the first frame update
    void Start()
    {
        
        currentOxygen = oxygenAmount;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateOxygen();
    }

    void UpdateOxygen()
    {
        currentOxygen -= Time.deltaTime;
        if (currentOxygen >= oxygenAmount) currentOxygen = oxygenAmount;
        if (currentOxygen <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        oxygenSlider.value = currentOxygen;
        //Debug.Log("oxygen: " + currentOxygen);
    }

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OxygenBubble"))
        {
            CollectOxygen(other.gameObject);
        }
    }

    void CollectOxygen(GameObject bubble)
    {
        bubbleCollectSound.Play();
        // Add oxygen to the player's supply
        float collectedOxygen = 30f;
        currentOxygen += collectedOxygen;

        // Ensure the oxygen doesn't exceed the maximum value
        if (currentOxygen > oxygenAmount)
            currentOxygen = oxygenAmount;

        // Disable the oxygen bubble until the next spawn
        Destroy(bubble);

        Debug.Log("Collected Oxygen! Current Oxygen: " + currentOxygen);
    }
}
