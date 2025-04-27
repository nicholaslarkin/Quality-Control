using UnityEngine;
using UnityEngine.UI;

public class RobotDirectionController : MonoBehaviour
{
    [Header("Robot Body")]
    public Sprite[] bodySprites;  // 8 sprites for robot body
    public Image robotBodyImage;  // Image for robot body

    [Header("Robot Treads")]
    public Sprite[] treadSprites; // 8 sprites for treads
    public Image robotTreadImage; // Image for treads

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 movement = transform.position - lastPosition;
        lastPosition = transform.position;

        Vector2 moveDirection = new Vector2(movement.x, movement.z);

        if (moveDirection.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            angle = (angle + 360f) % 360f;

            int index = GetDirectionIndex(angle);

            if (bodySprites != null && bodySprites.Length > index && robotBodyImage != null)
            {
                robotBodyImage.sprite = bodySprites[index];
            }

            if (treadSprites != null && treadSprites.Length > index && robotTreadImage != null)
            {
                robotTreadImage.sprite = treadSprites[index];
            }
        }
    }

    int GetDirectionIndex(float angle)
    {
        if (angle >= 337.5f || angle < 22.5f)
            return 0; // Right
        else if (angle >= 22.5f && angle < 67.5f)
            return 1; // Up-Right
        else if (angle >= 67.5f && angle < 112.5f)
            return 2; // Up
        else if (angle >= 112.5f && angle < 157.5f)
            return 3; // Up-Left
        else if (angle >= 157.5f && angle < 202.5f)
            return 4; // Left
        else if (angle >= 202.5f && angle < 247.5f)
            return 5; // Down-Left
        else if (angle >= 247.5f && angle < 292.5f)
            return 6; // Down
        else if (angle >= 292.5f && angle < 337.5f)
            return 7; // Down-Right

        return 0; // Default fallback
    }
}
