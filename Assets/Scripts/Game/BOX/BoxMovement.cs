using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveX;
    [SerializeField] private float moveZ;
    private void Start()
    {
        
    }
    void FixedUpdate()
    {
        
        transform.Translate(new Vector3(0f, 0f, moveZ * speed));

        //when it reaches the end, destroys self
        if (transform.position.x < -15.5)
        {
            Destroy(this.gameObject);
        }
   
    }
}
