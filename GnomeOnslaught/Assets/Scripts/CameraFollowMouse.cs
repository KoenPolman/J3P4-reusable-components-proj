using UnityEngine;

public class CameraFollowMouse : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Vector3 playerPos = player.position;
        playerPos.z = 0f;

        Vector3 targetPos = (playerPos + mouseWorldPos) / 2f;
        targetPos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothSpeed);
    }
}