using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player>().canMove = true;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent <Player>().canMove = false;
    }
}
