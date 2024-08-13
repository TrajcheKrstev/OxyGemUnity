using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCollector : MonoBehaviour
{
    public int totatlGems = 4;
    public float collectionSpeed = 5f;
    public float collectionRadius = 3f;
    public float buoyancyForce = 2f;
    public float destroyRadius = 1f;
    public float coneAngle = 100f; // Adjust the cone angle for the collection direction
    public AudioSource gemCollectSound;
    public AudioSource suctionSound;
    public TextMeshProUGUI gemsText;
    public GameObject portalPlane;
    private PauseMenuScript pauseMenuScript;


    public ParticleSystem collectionEffect;

    private bool isCollecting = false;
    private Transform targetGem;

    public int nGemsCollected = 0;

    private void Start()
    {
        pauseMenuScript = FindObjectOfType<PauseMenuScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] nearbyGems = Physics.OverlapSphere(transform.position, collectionRadius, LayerMask.GetMask("Gem"));

        //Debug.Log("Gems collected: " + nGemsCollected);
        if (!pauseMenuScript.isPaused && Input.GetMouseButton(1))
        {
            // Find nearby gems within the specified cone angle

            if (nearbyGems.Length > 0)
            {
                foreach (var gemCollider in nearbyGems)
                {
                    // Check if the gem is within the collection cone angle
                    Vector3 directionToGem = gemCollider.transform.position - transform.position;
                    float angleToGem = Vector3.Angle(Camera.main.transform.forward, directionToGem);
                    if (angleToGem <= coneAngle * 0.5f)
                    {
                        targetGem = gemCollider.transform;

                        // Disable physics for the gem while collecting
                        if (targetGem.GetComponent<Rigidbody>() != null)
                        {
                            targetGem.GetComponent<Rigidbody>().isKinematic = true;
                        }

                        // Start the particle system effect
                        if (collectionEffect != null)
                        {
                            collectionEffect.Play();
                        }

                        isCollecting = true;
                        break; // Break out of the loop after finding the first valid gem
                    }
                }
            }
        }

        // If collecting and F key is held down, move the gem towards the player
        if (!pauseMenuScript.isPaused && isCollecting && targetGem != null && Input.GetMouseButton(1))
        {
            if(!suctionSound.isPlaying) suctionSound.Play();
            float step = collectionSpeed * Time.deltaTime;

            // Move the gem towards the player in all three axes
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            targetGem.position = Vector3.MoveTowards(targetGem.position, targetPosition, step);


            // Check if the gem has reached the player
            if (Vector3.Distance(targetGem.position, targetPosition) < destroyRadius)
            {
                // Gem collected, remove or deactivate it
                nGemsCollected += 1;
                gemsText.text = nGemsCollected.ToString() + "/4";
                gemCollectSound.Play();
                Destroy(targetGem.gameObject);
                isCollecting = false;
                if (nGemsCollected == totatlGems) portalPlane.SetActive(true);
            }
        }
        else
        {
            if(suctionSound.isPlaying) suctionSound.Stop();
            // Enable physics for the gem
            if (targetGem != null && targetGem.GetComponent<Rigidbody>() != null)
            {
                targetGem.GetComponent<Rigidbody>().isKinematic = false;

                // Apply a buoyancy force to make the gem float
                targetGem.GetComponent<Rigidbody>().AddForce(Vector3.up * buoyancyForce, ForceMode.Acceleration);
            }

            // Stop the particle system effect
            if (collectionEffect != null)
            {
                collectionEffect.Stop();
            }

            // Stop collecting if space key is released
            isCollecting = false;
        }
    }
}