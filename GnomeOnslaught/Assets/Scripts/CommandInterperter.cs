using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CommandInterperter : MonoBehaviour
{
    private UnitBehavior unitBehavior;
    private Rigidbody2D rigidbody2D;
    private Vector2 movementDirection;
    private UnitBehaviorType currentUnitBehavior = UnitBehaviorType.idle;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        unitBehavior = GetComponent<UnitBehavior>();
    }
    void Update()
    {
        switch (currentUnitBehavior)
        {
            case UnitBehaviorType.idle:
                movementDirection = Vector2.zero;
                break;
            case UnitBehaviorType.attacking:
                AttackTarget(unitBehavior.target);
                break;
            case UnitBehaviorType.following:
                FollowTarget(unitBehavior.target);
                break;
            default:
                break;
        }

        GetComponent<Rigidbody2D>().AddForce(movementDirection);
    }
    void AttackTarget(GameObject targetToFollow)
    {
        Vector2 direction = (targetToFollow.transform.position - transform.position).normalized;
        Debug.DrawLine(transform.position, targetToFollow.transform.position, Color.red);
        Debug.Log("Direction: " + direction);
    }

    void GoToDirection()
    {

    }

    void FollowTarget(GameObject targetToFollow)
    {
        Vector2 toTarget = targetToFollow.transform.position - transform.position;
        float currentDistance = toTarget.magnitude;
        // Only move if we're farther than the desired distance
        if (currentDistance > 1)
        {
            Vector2 direction = toTarget.normalized;
            rigidbody2D.AddForce(direction);
        }
    }
}
