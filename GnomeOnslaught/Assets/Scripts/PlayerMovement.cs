using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10;
    private IControls controls;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        controls = new KeyboardControls(gameObject);
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 movementDir = controls.GetMovement();
        Vector2 aim = controls.GetAim();

        if (controls.SelectPressed())
        {
            Debug.Log("Select pressed");
        }

        if (controls.ReturnPressed())
        {
            Debug.Log("Return pressed");
        }

        Vector2 movement = movementDir * movementSpeed;
        rigidbody2D.AddForce(movement);
    }
}
