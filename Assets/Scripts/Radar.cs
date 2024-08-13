using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private Transform sweepTransform;
    public float rotationSpeed = 180f;

    public GameObject[] trackedObjects;
    List<GameObject> radarObjects;
    public GameObject radarPrefab;
    List<GameObject> borderObjects;
    public float switchDistance = 10f;
    public Transform helpTransform;


    private void Awake()
    {
        sweepTransform = transform.Find("RadarLine");
    }

    // Start is called before the first frame update
    void Start()
    {
        createRadarObjects();
    }

    // Update is called once per frame
    void Update()
    {
        sweepTransform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);

        for (int i = 0; i < radarObjects.Count; i++)
        {
            if (radarObjects[i] == null) continue; 
            if (Vector3.Distance(radarObjects[i].transform.position, transform.position) > switchDistance)
            {
                helpTransform.LookAt(radarObjects[i].transform);
                borderObjects[i].transform.position = transform.position + switchDistance * helpTransform.forward;
                borderObjects[i].layer = LayerMask.NameToLayer("Radar");
                radarObjects[i].layer = LayerMask.NameToLayer("Invisible");

            }
            else
            {
                borderObjects[i].layer = LayerMask.NameToLayer("Invisible");
                radarObjects[i].layer = LayerMask.NameToLayer("Radar");

            }
        }
    }

    void createRadarObjects()
    {
        radarObjects = new List<GameObject>();
        borderObjects = new List<GameObject>();
        foreach (GameObject o in trackedObjects)
        {
            // Instantiate radar object
            GameObject radarPoint = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;

            // Set the parent of the radar point to the desired object (e.g., player)
            radarPoint.transform.parent = o.transform;

            radarObjects.Add(radarPoint);

            // Instantiate border object (if needed)
            GameObject borderPoint = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;

            //// Set the parent of the border point to the desired object (e.g., player)
            //borderPoint.transform.parent = o.transform;

            borderObjects.Add(borderPoint);
        }
    }
}
