using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints = 10;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
    void TakeDamage(float damage)
    {
        healthPoints -= damage;
    }
}
