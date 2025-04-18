using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 100;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private Vector3 forceDirection = new Vector3(1f, 0f, 1f).normalized;

    [Header("Jump")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpValue = 5f;

    [Header("Knockback")]
    [SerializeField] private float knockbackValue;
    [SerializeField] private Vector3 knockupVector = new Vector3(0,10,0);
    [SerializeField] private Vector3 boxSize = new Vector3(3,3,3);
    [SerializeField] private float boxDistance = 2f;
    [SerializeField] private float pushCooldown = 1f;
    [SerializeField] private float cooldownRemaining = 1f;

    [SerializeField] private Vector3 boxCenter;


    [Header("Rigidbody/Input")]
    //public Rigidbody2D rb2d;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector2 move;
    [SerializeField] private InputManager inputManager;

    [Header("Player Information")]
    [SerializeField] public int PlayerNumber => playerNumber;
    private int playerNumber;

    //set player number
    private void setPlayer(int n)
    {
        playerNumber = n;
    }
    void Start()
    {
        inputManager = this.gameObject.GetComponent<InputManager>();
    }


    void Update()
    {
        boxCenter = transform.position + transform.forward * boxDistance;
        horizontalInput = inputManager.movementVector.x;
        verticalInput = inputManager.movementVector.y;
        cooldownRemaining -= Time.deltaTime;
    }

    //check if player is on ground for jump
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if player is on the ground
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    //calls movement in fixed update
    public void FixedUpdate()
    {
        Move();
        
    }
    public void Move()
    {
        Vector3 movement = new Vector3 (horizontalInput,0, verticalInput);
        rb.AddForce(movement* speed);
        //rb.linearVelocity = movement * speed;

        Vector3 friction = new Vector3(-rb.linearVelocity.x, -2f, -rb.linearVelocity.z);
        //rotate the player towards the velocity
        if (rb.linearVelocity.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rb.linearVelocity.normalized);
            rb.MoveRotation(Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f));
        }
        
        rb.AddForce(friction * speed * 0.1f);


    }

    //jump when not on ground
    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpValue, ForceMode.Impulse);
        }
    }
    //push ability
    public void Push()
    {
        Debug.Log("pushed");
        if (cooldownRemaining <= 0) {
            cooldownRemaining -= Time.deltaTime;
            Collider[] hits = Physics.OverlapBox(boxCenter, boxSize/2 ,transform.rotation);

            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    Vector3 direction = (hit.transform.position - transform.position).normalized + knockupVector ;
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    rb.AddForce(direction * knockbackValue, ForceMode.Impulse);
                }
            }
            cooldownRemaining = pushCooldown;
        }
        
    }
    void DebugDrawBox(Vector3 center, Vector3 size, Quaternion rotation, Color color)
    {
        Matrix4x4 matrix = Matrix4x4.TRS(center, rotation, size);
        Gizmos.color = color;
        Gizmos.matrix = matrix;
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }

    void OnDrawGizmos()
    {
        Vector3 boxCenter = transform.position + transform.forward * boxDistance;
        DebugDrawBox(boxCenter, boxSize, transform.rotation, Color.green);
    }

}
