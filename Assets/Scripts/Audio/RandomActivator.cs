using UnityEngine;

public class RandomActivator : MonoBehaviour
{
    [Header("Game Objects to Activate")]
    public GameObject[] objects;

    void Start()
    {
        // Deactivate all objects first
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        // Pick a random number between 0 and 7
        int randomIndex = Random.Range(0, 8);

        // Activate the chosen object if the index is valid
        if (randomIndex < objects.Length)
        {
            objects[randomIndex].SetActive(true);
            Debug.Log("Activated object: " + objects[randomIndex].name);
        }
    }
}
