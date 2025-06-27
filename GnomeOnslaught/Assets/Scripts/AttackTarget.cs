using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    [SerializeField] float damageAmount = 1;
    private UnitMovement unitMovement;
    private GameObject target;
    private Health healthOfTarget;
    private CircleCollider2D circleCollider;
    private CircleCollider2D circleColliderOfTarget;
    private void Start()
    {
        healthOfTarget = target.gameObject.GetComponent<Health>();
        circleColliderOfTarget = target.GetComponent<CircleCollider2D>();

        unitMovement = GetComponent<UnitMovement>();
        circleCollider = GetComponent<CircleCollider2D>();
        SeekEnemy seekEnemy = gameObject.AddComponent<SeekEnemy>();
        seekEnemy.enabled = false;

        //if (circleCollider == null)
        //{
        //    Debug.Log("unit collider is null");
        //}

        //if (circleColliderOfTarget == null)
        //{
        //    Debug.Log("target collider is null");
        //}
    }
    void FixedUpdate()
    {
        if (circleColliderOfTarget == null)
        {
            //Debug.Log("target does not exist anymore");
            GetComponent<SeekEnemy>().enabled = true;
            GetComponent<BehaviorManager>().SetBehavior<Idle>();
        }
        else
        {
            //Debug.Log("running attack behavior");
            Vector2 toTarget = target.transform.position - transform.position;
            float currentDistance = toTarget.magnitude; //calculate the direction to the target
            Vector2 direction = toTarget.normalized;
            unitMovement.MoveInDirection(direction); //go to the enemy
            if (circleCollider.IsTouching(circleColliderOfTarget)) //if is touching do damage
            {
                healthOfTarget.TakeDamage(damageAmount, gameObject.transform.position);
            }
        }
    }
    public GameObject Target
    {
        get => target;
        set => target = value;
    }
}
