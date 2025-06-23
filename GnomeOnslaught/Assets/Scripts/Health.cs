using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float healthPoints = 10;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (rb != null)
        {
            rb.AddForce(-(damageOrgin * 2 * 10));
        }
        healthPoints -= damage;
    }
}