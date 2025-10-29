using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITurretFollowMouse : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform turretRotationPoint;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private float angleOffset = -90f; // Adjust if turret faces up

    private void Update()
    {
        RotateTowardsMouse();
    } 
    private void Start()
    {
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        // Convert screen position to world position
        Vector2 mouseScreenPos = Input.mousePosition;

        Vector3 worldMousePos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            canvas.transform as RectTransform,
            mouseScreenPos,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera,
            out worldMousePos
        );

        // Direction from turret to mouse
        Vector3 direction = worldMousePos - turretRotationPoint.position;

        // Calculate angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;

        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

        turretRotationPoint.rotation = Quaternion.RotateTowards(
            turretRotationPoint.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
    }
}