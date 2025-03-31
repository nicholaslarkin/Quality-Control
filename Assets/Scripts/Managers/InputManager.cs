using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    
    
    public Vector2 movementVector = Vector2.zero;
    

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        movementVector = callbackContext.ReadValue<Vector2>();
        
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            GetComponent<Player>().Jump();
            Debug.Log("Jump!");
        }
    }
    public void OnAction(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            GetComponent<Player>().Push();
            Debug.Log("Action!");
        }
    }
    
}
