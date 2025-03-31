using UnityEngine;

public class KOTHCircle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public void OnTriggerEnter(Collider other)
    {
        //eventually find gameobject through playermanager
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<KOTHTimer>().countingDown = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<KOTHTimer>().countingDown = false;
        }
    }
}
