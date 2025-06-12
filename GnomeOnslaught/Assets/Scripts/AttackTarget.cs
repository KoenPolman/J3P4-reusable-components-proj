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
        Destroy(gameObject.AddComponent<SeekEnemy>());
    }
    void FixedUpdate()
    {
        Vector2 toTarget = target.transform.position - transform.position;
        float currentDistance = toTarget.magnitude;
        Vector2 direction = toTarget.normalized;
        unitMovement.MoveInDirection(direction);
        if (circleCollider.IsTouching(circleColliderOfTarget))
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
