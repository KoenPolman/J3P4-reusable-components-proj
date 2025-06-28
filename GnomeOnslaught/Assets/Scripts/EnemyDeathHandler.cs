using UnityEngine;

public class EnemyDeathHandler : MonoBehaviour
{
    private PlayerWinHandler playerWinHandler;
    private void Start()
    {
        // You could find the player by tag or manually assign it
        playerWinHandler = FindObjectOfType<PlayerWinHandler>();
    }
    public void OnDeath()
    {
        // Then notify the player handler
        if (playerWinHandler != null)
        {
            playerWinHandler.CheckForEnemies();
        }
    }
}
