using UnityEngine;

public class FollowNoRotate : MonoBehaviour
{
    [SerializeField] private Transform target; // The object to follow (e.g., the player)

    void LateUpdate()
    {
        if (target == null) return;

        // Match the target's position
        transform.position = target.position;

        // Freeze rotation to identity (no rotation)
        transform.rotation = Quaternion.identity;
    }
}
