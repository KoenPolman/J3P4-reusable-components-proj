using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints = 10;
    Rigidbody rb;

    public static event Action<GameObject> OnUnitDied;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(float damage, Vector3 damageOrigin)
    {
        Debug.Log("health = " + healthPoints);
        if (rb != null)
        {
            rb.AddForce(-(damageOrigin * 2 * 10));
        }
        healthPoints -= damage;

        if (healthPoints <= 0)
        {
            CheckForOnDeathHandler();
            Destroy(gameObject);
        }
    }
    private void CheckForOnDeathHandler()
    {
        if (GetComponent<AlliedUnitDeathHandler>() != null)
        {
            GetComponent<AlliedUnitDeathHandler>().OnDeath(OnUnitDied);
        }
        if (GetComponent<EnemyDeathHandler>() != null)
        {
            GetComponent<EnemyDeathHandler>().OnDeath();
        }
        if (GetComponent<PlayerDeathHandler>() != null)
        {
            GetComponent<PlayerDeathHandler>().OnDeath();
        }
    }
}