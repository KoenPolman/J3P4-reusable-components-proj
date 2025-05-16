using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private IControls controls;

    void Start()
    {
        controls = new KeyboardControls();
    }

    void Update()
    {
        Vector2 movement = controls.GetMovement();
        Vector2 aim = controls.GetAim();

        if (controls.SelectPressed())
        {
            Debug.Log("Select pressed");
        }

        if (controls.ReturnPressed())
        {
            Debug.Log("Return pressed");
        }

    }
}
