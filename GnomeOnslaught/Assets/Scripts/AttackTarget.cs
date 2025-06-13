using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    [SerializeField] float damageAmount = 3;
    private UnitMovement unitMovement;
    private Transform target;
    private Health healthOfTarget;
    private CircleCollider2D circleCollider;
    private CircleCollider2D circleColliderOfTarget;
    private void Start()
    {
        unitMovement = GetComponent<UnitMovement>();
        CommandAdresser t = GameObject.FindFirstObjectByType<CommandAdresser>();
        target = t.gameObject.transform;
        healthOfTarget = t.GetComponentInParent<Health>();
        circleCollider.GetComponent<CircleCollider2D>();
        circleColliderOfTarget = t.GetComponent<CircleCollider2D>();
        SeekEnemy seekEnemy = gameObject.AddComponent<SeekEnemy>();
        seekEnemy.enabled = false;
    }
    void FixedUpdate()
    {
        Vector2 toTarget = target.transform.position - transform.position;
        float currentDistance = toTarget.magnitude; //calculate the direction to the target
        Vector2 direction = toTarget.normalized;
        unitMovement.MoveInDirection(direction); //go to the enemy
        if (circleCollider.IsTouching(circleColliderOfTarget)) //if is touching do damage
        {
            healthOfTarget.TakeDamage(damageAmount, gameObject.transform.position);
        }
    }
    public Transform Target
    {
        get => target;
        set => target = value;
    }
}
