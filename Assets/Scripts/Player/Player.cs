using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float maxAcceleration;

    [Header("Rigidbody/Input")]
    public Rigidbody rb;
    private Vector2 move;

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        move = callbackContext.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Jump();
            Debug.Log("Jump!");
        }
    }

    public void OnAction(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Action();
            Debug.Log("Action!");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Jump()
    {

    }

    void Action()
    {

    }
}
