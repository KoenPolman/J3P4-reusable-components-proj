using UnityEngine;

public class ExplosiveDeathHandler : MonoBehaviour
{
    public void OnDeath()
    {
        Health[] units = FindObjectsByType<Health>(FindObjectsSortMode.None);
        for (int i = 0; i < units.Length; i++)
        {
            float distance = Vector3.Distance(units[i].transform.position, transform.position);
            if (distance < 3 && gameObject != units[i].gameObject)
            {
                units[i].TakeDamage(999, transform.position);
            }
        }
    }
}
