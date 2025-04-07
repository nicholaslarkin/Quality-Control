using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float maxAcceleration;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    [Header("Jump")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpValue = 5f;

    [Header("Knockback")]
    [SerializeField] private float knockValue = 5f;
    [SerializeField] private float knockRange = 2f;
    [SerializeField] private float pushCooldown = 1f;
    [SerializeField] private float cooldownRemaining = 1f;


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
        rb.linearVelocity = movement * speed;
        Vector3 friction = new Vector3(-rb.linearVelocity.x, -2f, -rb.linearVelocity.z);
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
        if (cooldownRemaining <= 0) {
            cooldownRemaining -= Time.deltaTime;
            Collider[] hits = Physics.OverlapSphere(transform.position, knockRange);

            foreach (Collider hit in hits)
            {
                if (hit.CompareTag("Player"))
                {
                    Vector3 direction = (hit.transform.position - transform.position).normalized;
                    Rigidbody rb = hit.GetComponent<Rigidbody>();
                    rb.AddForce(direction * knockValue, ForceMode.Impulse);
                }
            }
            cooldownRemaining = pushCooldown;
        }
        
    }
}
