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
                //Debug.Log("idling");
                break;
            case UnitBehaviorType.attacking:
                AttackTarget(unitBehavior.target);
                //Debug.Log("attacking");
                break;
            case UnitBehaviorType.following:
                FollowTarget(unitBehavior.target);
                //Debug.Log("following");
                break;
            default:
                //Debug.Log("no behavior executed");
                break;
        }

        GetComponent<Rigidbody2D>().AddForce(movementDirection);
    }
    public void SetUnitBehavior(UnitBehaviorType _newUnitBehavior)
    {
        //Debug.Log("New unit behavior set");
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
        //Debug.Log("following target");
        Vector2 toTarget = targetToFollow.transform.position - transform.position;
        float currentDistance = toTarget.magnitude;
        Debug.Log("current distcance : " + currentDistance);
        if (currentDistance >= 1)
        {
            //Debug.Log("Moving to target");
            Vector2 direction = toTarget.normalized;
            rigidbody2D.AddForce(direction);
        }
    }
}
