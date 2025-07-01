using UnityEngine;

public class Jitter : MonoBehaviour
{
    [SerializeField] float intensity = 1f;
    [SerializeField] float frequency = 2f;

    private UnitMovement unitMovement;
    private float timer;

    void Start()
    {
        unitMovement = GetComponent<UnitMovement>();
        timer = 0f;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 1f / frequency)
        {
            ApplyJitter();
            timer = 0f;
        }
    }

    void ApplyJitter()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized * intensity;
        unitMovement.MoveInDirection(randomDir);
    }
}
