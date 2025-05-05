using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float lifetime = 10f; // seconds before self-destruction

    private Vector3 moveDirection;

    void Start()
    {
        moveDirection = (Vector3.zero - transform.position).normalized;
        Destroy(gameObject, lifetime); // Schedule destruction
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
