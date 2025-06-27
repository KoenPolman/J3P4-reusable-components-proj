using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPrefab;
    private GameObject pauseMenuInstance;
    private Rigidbody2D[] RBsToPause;

    private void Update()
    {
        if (Input.GetButtonDown("`"))
        {
            PauseGame();
        }
    }
    private void PauseGame()
    { 
        pauseMenuInstance = Instantiate(pauseMenuPrefab, gameObject.transform);//instantiate the pause menu prefab
        //find game objects, of type rigid body and unitspawner
        //put all game objects on pause
    }
    private void UnPauseGame()
    {
        Destroy(pauseMenuInstance);//get rid of recently instantiated pause menu
        //unpause all gameobjects
    }
}
