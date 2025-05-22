using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public Transform player; // Reference to the player character
    public float smoothSpeed = 5f; // Higher = faster camera movement

    void LateUpdate()
    {
        if (player == null) return;

        // Get mouse position in world space
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        // Get player position
        Vector3 playerPos = player.position;
        playerPos.z = 0f;

        // Calculate target position (midpoint)
        Vector3 targetPos = (playerPos + mouseWorldPos) / 2f;
        targetPos.z = transform.position.z; // Maintain current Z

        // Smoothly interpolate camera position
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
    }
}