using UnityEngine;

public class CommandInterperter : MonoBehaviour
{
    private UnitBehavior unitBehavior;
    private Vector2 movementDirection;

    void Start()
    {
        unitBehavior = GetComponent<UnitBehavior>();
    }
    void Update()
    {

        unitBehavior.movementDirection = movementDirection;
    }

    void followTarget(GameObject targetToFollow)
    {

    }

    void GoToDirection()
    {

    }
    void SeekEnemy()
    {

    }
}
