using Unity.VisualScripting;
using UnityEngine;

public class KeyboardControls : IControls
{
    GameObject player;
    public KeyboardControls(GameObject _player)
    {
        player = _player;
    }
    public Vector2 GetMovement()
    {
        //Debug.Log("check input");
        Vector2 movementDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            movementDirection.y = 0;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            movementDirection.y = 1;
            //Debug.Log("forward");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementDirection.y = -1;
            //Debug.Log("backward");
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            movementDirection.x = 0;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementDirection.x = -1;
            //Debug.Log("left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movementDirection.x = 1;
            //Debug.Log("right");
        }
        movementDirection.Normalize();
        return movementDirection;
    }
    public Vector2 GetAim()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f;

        Vector3 direction = mouseWorldPosition - player.transform.position;
        direction.z = 0f;

        return direction.normalized;
    }
    public bool SelectPressed()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
    public bool ReturnPressed()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("return was pressed");
        }
        return Input.GetKeyDown(KeyCode.Q);
    }
}
