using UnityEngine;

public class KOTHCircle : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        // if gameobject touching trigger and is a player, start countdown
        if (other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<KOTHTimer>().countingDown = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<KOTHTimer>().countingDown = false;
        }
    }
}
