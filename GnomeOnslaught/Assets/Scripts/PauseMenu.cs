using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPrefab;
    private GameObject pauseMenuInstance;
    private List<MonoBehaviour> componentsToPause;
    private List<Rigidbody2D> rigidbody2Ds;
    private IControls controls = new KeyboardControls();
    private bool gameIsPaused = false;

    public GameObject GetPauseMenuObject() { return pauseMenuInstance; }
    public List<MonoBehaviour> GetComponentsToPause() { return componentsToPause; }
    public List<Rigidbody2D> GetRigidbody2Ds() { return rigidbody2Ds; }
    private void Start()
    {
        componentsToPause = new List<MonoBehaviour>();
        rigidbody2Ds = new List<Rigidbody2D>();
    }
    private void Update()
    {
        if (controls.PausePressed() && !gameIsPaused)
        {
            PauseGame();
            gameIsPaused = true;
        }
    }
    private void PauseGame()
    {
        componentsToPause.AddRange(FindObjectsByType<UnitSpawner>(FindObjectsSortMode.None));//find game objects, of type rigid body and unitspawner
        rigidbody2Ds.AddRange(FindObjectsByType<Rigidbody2D>(FindObjectsSortMode.None));
        foreach (MonoBehaviour toPause in componentsToPause)//put all game objects on pause
        {
            //Debug.Log("a component is paused");
            toPause.enabled = false;
        }
        foreach (Rigidbody2D toPause in rigidbody2Ds)
        {
            //Debug.Log("a rigidbody is paused");
            toPause.bodyType = RigidbodyType2D.Static;
        }
        pauseMenuInstance = Instantiate(pauseMenuPrefab, gameObject.transform);//instantiate the pause menu prefab
    }
    public void GameUnpause()
    {
        gameIsPaused = false;
        componentsToPause.Clear();
        rigidbody2Ds.Clear();
    }
}
