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
    public void TakeDamage(float damage, Vector3 damageOrgin)
    {
        Debug.Log("health = " + 0);
        healthPoints -= damage;
    }
}