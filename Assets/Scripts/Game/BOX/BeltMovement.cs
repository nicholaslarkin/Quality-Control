using UnityEditor.Rendering;
using UnityEngine;

public class BeltMovement : MonoBehaviour
{
    [SerializeField] private float beltPushForce;
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0).normalized* beltPushForce, ForceMode.Force);
            Debug.Log("BeltTriggered");
            other.gameObject.GetComponent<KOTHTimer>().enabled = false;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        }
    }

}
