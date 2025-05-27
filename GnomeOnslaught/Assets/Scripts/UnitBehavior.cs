using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] FactionTypes faction;
    private UnitBehaviorType currentUnitBehavior = UnitBehaviorType.idle;
    private GameObject target;
    public Vector2 movementDirection;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch(currentUnitBehavior)
        {
            case UnitBehaviorType.idle:
                break;
            case UnitBehaviorType.attacking:
                AttackTarget(target);
                break;
            case UnitBehaviorType.following:
                break;
                FollowTarget(target); break;
            default;
                break;
        }

        rigidbody2D.AddForce(movementDirection);
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
