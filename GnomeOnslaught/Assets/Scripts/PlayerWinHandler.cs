using UnityEngine;

public class PlayerWinHandler : MonoBehaviour
{
    [SerializeField] private GameObject winscreen;
    public void CheckForEnemies()
    {
        EnemyDeathHandler[] remainingEnemies = FindObjectsOfType<EnemyDeathHandler>();
        Debug.Log("total amount of enemies remaining : " + remainingEnemies.Length);
        if (remainingEnemies.Length <= 1) //this code is ran before the enemy is removed so amount of enemies in reality is +1 here when checked
        {
            WinConditionAchieved();
        }
    }

    public void WinConditionAchieved()
    {
        GameObject canvas = FindAnyObjectByType<Canvas>().gameObject;
        Instantiate(winscreen, canvas.transform);
    }
}
