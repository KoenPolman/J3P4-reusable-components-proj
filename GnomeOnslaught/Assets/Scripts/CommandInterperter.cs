using UnityEngine;

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
    public void SetUnitBehavior(UnitBehaviorType _newUnitBehavior)
    {
        currentUnitBehavior = _newUnitBehavior;
        UnitBehavior unitBehavior = GetComponent<UnitBehavior>();
        unitBehavior.target = gameObject;
    }

    private void AttackTarget(GameObject targetToFollow)
    {
        Vector2 direction = (targetToFollow.transform.position - transform.position).normalized;
        Debug.DrawLine(transform.position, targetToFollow.transform.position, Color.red);
        //Debug.Log("Direction: " + direction);
    }

    private void GoToDirection()
    {

    }

    private void FollowTarget(GameObject targetToFollow)
    {
        Debug.Log("following target");
        Vector2 toTarget = targetToFollow.transform.position - transform.position;
        float currentDistance = toTarget.magnitude;
        if (currentDistance > 1)
        {
            Vector2 direction = toTarget.normalized;
            rigidbody2D.AddForce(direction);
        }
    }
}
