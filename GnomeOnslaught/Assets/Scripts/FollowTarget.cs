using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Transform target;
    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); 
        CommandAdresser t = GameObject.FindFirstObjectByType<CommandAdresser>();
        target = t.gameObject.transform;
    }

    void FixedUpdate()
    {
        //Debug.Log("following target");
        Vector2 toTarget = target.transform.position - transform.position;
        float currentDistance = toTarget.magnitude;
        Vector2 direction = toTarget.normalized;
        //Debug.Log("current distance : " + currentDistance);
        if (currentDistance >= 1.5f)
        {
            //Debug.Log("Moving to target");
            //Debug.Log(toTarget);
            //Debug.Log(direction);
            rigidbody2D.AddForce(direction);
        }
        else if (currentDistance < 1.5f)
        {
            direction = -direction * 2;
            rigidbody2D.AddForce(direction);
        }
    }
}
