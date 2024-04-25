using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar_Script : MonoBehaviour
{
    public GameObject pillarPrefab; // Assign your pillar prefab in the inspector
    public GameObject PointTrackerPrefab;
    public float spawnRate = 5f; // How often to spawn pillars
    public float pillarSpeed = 2f; // Speed of the pillars
    private float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    // Update is called once per frame
    void Update()
    {   // Check if it's time to spawn a new pillar
        if (Time.time > nextSpawnTime)
        {
            SpawnPillar();
            nextSpawnTime = Time.time + spawnRate;
        }
        // Move all the pillars to the left of the screen then destroy them if they are off screen
        foreach (Transform child in transform)
        {
            child.position -= new Vector3(pillarSpeed * Time.deltaTime, 0, 0);

            // Check if the pillar has moved past the left edge of the camera
            if (child.position.x < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x)
            {
                Destroy(child.gameObject);
            }
        }
    }

    void SpawnPillar()
    {
    // Get the world coordinates of the top and bottom of the screen
    float top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    float bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

    // Generate a random offset
    float offset = Random.Range(-1f, 1f);

    // Spawn a pillar at the top of the screen with a random offset
    Vector3 topSpawnPosition = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x, top + offset, 0);
    GameObject topPillar = Instantiate(pillarPrefab, topSpawnPosition, Quaternion.identity, transform);

    // Spawn a pillar at the bottom of the screen with a random offset
    Vector3 bottomSpawnPosition = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x, bottom + offset, 0);
    GameObject bottomPillar = Instantiate(pillarPrefab, bottomSpawnPosition, Quaternion.identity, transform);

    //Spawn Point Tracker
    Vector3 PointTrackerSpawn = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x, bottom, 0);
     GameObject PointTracker = Instantiate(PointTrackerPrefab, PointTrackerSpawn, Quaternion.identity, transform);

    // Assign random colors to the pillars
    topPillar.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    bottomPillar.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
    

}