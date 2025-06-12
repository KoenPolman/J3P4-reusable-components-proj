using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private UnitMovement unitMovement;
    private Transform target;
    
    void Start()
    {
        unitMovement = GetComponent<UnitMovement>(); 
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
            unitMovement.MoveInDirection(direction);
        }
        else if (currentDistance < 1.5f)
        {
            direction = -direction * 2;
            unitMovement.MoveInDirection(direction);
        }
    }
}
