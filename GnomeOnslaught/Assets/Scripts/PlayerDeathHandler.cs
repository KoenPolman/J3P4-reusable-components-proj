using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    public void OnDeath()
    {
        GameObject canvas = FindAnyObjectByType<Canvas>().gameObject;
        Instantiate(GameOverScreen, canvas.transform);
    }
}
