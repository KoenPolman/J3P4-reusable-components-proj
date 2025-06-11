using UnityEngine;

public class AttackTarget : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Transform target;
    private Health healthOfTarget;
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        CommandAdresser t = GameObject.FindFirstObjectByType<CommandAdresser>();
        target = t.gameObject.transform;
        healthOfTarget = t.GetComponentInParent<Health>();
    }
    void FixedUpdate()
    {
        Vector2 toTarget = target.transform.position - transform.position;
        float currentDistance = toTarget.magnitude;
        Vector2 direction = toTarget.normalized;
        rigidbody2D.AddForce(direction);
    }
}
