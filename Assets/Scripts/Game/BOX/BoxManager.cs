using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class BoxManager: MonoBehaviour
{
    [SerializeField] private List<GameObject> playerSpawnsBOX = new List<GameObject>();
    [SerializeField] private List<GameObject> boxes = new List<GameObject>();
    [SerializeField] private float minInterval; // Minimum interval between instantiations
    [SerializeField] private float maxInterval; // Starting interval
    [SerializeField] private float intervalReductionRate; // Rate at which the interval shortens over time
    //[SerializeField] private float zMin = 12.54f; // Minimum Z position for random range
    //[SerializeField] private float zMax = 21.8f; // Maximum Z position for random range
    [SerializeField] private float spawnCount = 1;

    private float timer; // Timer to track the time between instantiations
    private void Start()
    {
        if (PlayerManager.playerList.Count >= 1) {
            PlayerManager.playerList[0].GetComponent<Transform>().position = playerSpawnsBOX[0].GetComponent<Transform>().position;
            Debug.Log("Moved Player");

        }

        if (PlayerManager.playerList.Count >= 2)
            PlayerManager.playerList[1].GetComponent<Transform>().position = playerSpawnsBOX[1].GetComponent<Transform>().position;
        if (PlayerManager.playerList.Count >= 3)
            PlayerManager.playerList[2].GetComponent<Transform>().position = playerSpawnsBOX[2].GetComponent<Transform>().position;
        if (PlayerManager.playerList.Count >= 4)
            PlayerManager.playerList[3].GetComponent<Transform>().position = playerSpawnsBOX[3].GetComponent<Transform>().position;

    }
    
    //take out of update and call every x time so the interval reduction is constant
    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if the timer has passed the current interval
        if (timer >= maxInterval)
        {

            // Instantiate the prefab at a random Z position
            for (int i = 0; i < spawnCount; i++)
            {
                InstantiatePrefab();
            }
            // Reset the timer
            timer = 0f;

            // Shorten the interval over time (but ensure it doesn't go below the minimum interval)
            maxInterval = Mathf.Max(minInterval, maxInterval - intervalReductionRate);
        }
        if (maxInterval == minInterval)
        {
            spawnCount++; // Increase spawn count as the interval decreases
            maxInterval = 2f;
        }
    }

    void InstantiatePrefab()
    {
        // gets a random box to spawn
        int randomBox = Random.Range(0,6);


        // Instantiate the prefab at (0, 0, randomZ) and set its rotation to the identity (no rotation)
        Instantiate(boxes[randomBox], boxes[randomBox].transform.position, Quaternion.Euler(0,45,0));
    }
}
