using System.Collections;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float initialSpawnInterval = 2.5f;
    [SerializeField] private float spawnAcceleration = 0.95f; //must be < 1 to reduce interval
    [SerializeField] private float minSpawnInterval = 0.2f;

    private float currentInterval;

    void Start()
    {
        currentInterval = initialSpawnInterval;
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObject();

            yield return new WaitForSeconds(currentInterval);

            // Gradually decrease the interval
            currentInterval = Mathf.Max(minSpawnInterval, currentInterval * spawnAcceleration);
        }
    }

    void SpawnObject()
    {
        //gets position along circle circumference and spawns object on it, facing 0 (center of stage)
        float angle = Random.Range(0f, Mathf.PI * 2);
        Vector3 spawnPos = new Vector3(
            Mathf.Cos(angle) * radius,
            0,
            Mathf.Sin(angle) * radius
        );

        GameObject obj = Instantiate(laser, spawnPos, Quaternion.identity);
        obj.transform.LookAt(Vector3.zero);
    }
}

