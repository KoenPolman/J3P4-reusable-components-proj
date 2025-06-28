using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    private Rigidbody2D rigidbody2D;
    private IControls controls;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void MoveInDirection(Vector3 direction)
    {
        rigidbody2D.AddForce(direction * movementSpeed);
    }
}
