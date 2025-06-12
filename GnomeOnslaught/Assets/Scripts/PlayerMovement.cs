using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private IControls controls;
    private UnitMovement unitMovement;

    void Start()
    {
        controls = new KeyboardControls(gameObject);
        unitMovement = GetComponent<UnitMovement>();
    }

    void FixedUpdate()
    {
        Vector2 movementDir = controls.GetMovement();
        Vector2 aim = controls.GetAim();

        //if (controls.SelectPressed())
        {
            //Debug.Log("Select pressed");
        }

        //if (controls.ReturnPressed())
        {
            //Debug.Log("Return pressed");
        }

        unitMovement.MoveInDirection(movementDir);
    }
}
