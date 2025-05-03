using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Direction Sprites")]
    public Sprite[] bodySprites;           // 8 directional sprites for the robot body
    public Image robotBodyImage;           // UI Image component for robot body

    public Sprite[] treadSprites;          // 8 directional sprites for the robot treads
    public Image robotTreadImage;          // UI Image component for robot treads

    [Header("UI Tracking Settings")]
    public Transform followTarget3D;       // Empty anchor point in the 3D world
    public Camera mainCamera;              // Main gameplay camera
    public RectTransform uiRoot;           // The RectTransform that holds the UI sprite group

    private Vector3 lastWorldPosition;

    void Start()
    {
        if (followTarget3D != null)
        {
            lastWorldPosition = followTarget3D.position;
        }
    }

    void LateUpdate()
    {
        UpdateDirectionSprites();
        UpdateSpriteFollow();
    }

    void UpdateDirectionSprites()
    {
        if (followTarget3D == null)
            return;

        Vector3 movement = followTarget3D.position - lastWorldPosition;
        lastWorldPosition = followTarget3D.position;

        Vector2 moveDir = new Vector2(movement.x, movement.z);

        if (moveDir.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            angle = (angle + 360f) % 360f;

            int index = GetDirectionIndex(angle);

            if (bodySprites != null && bodySprites.Length > index && robotBodyImage != null)
                robotBodyImage.sprite = bodySprites[index];

            if (treadSprites != null && treadSprites.Length > index && robotTreadImage != null)
                robotTreadImage.sprite = treadSprites[index];
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

        return 0;
    }

    void UpdateSpriteFollow()
    {
        if (followTarget3D == null || mainCamera == null || uiRoot == null)
            return;

        Vector3 screenPos = mainCamera.WorldToScreenPoint(followTarget3D.position);

        Vector2 uiPos;
        RectTransform canvasRect = uiRoot.root as RectTransform;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out uiPos))
        {
            uiRoot.anchoredPosition = uiPos;
        }
    }
}
