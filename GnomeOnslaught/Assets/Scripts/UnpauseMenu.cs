using System.Collections.Generic;
using UnityEngine;

public class UnpauseMenu : MonoBehaviour
{
    private GameObject pauseMenuInstance;
    private List<MonoBehaviour> componentsToPause;
    private List<Rigidbody2D> rigidbody2Ds;
    private PauseMenu pauseMenu;
    void Start()
    {
        pauseMenu = FindAnyObjectByType<PauseMenu>();
        pauseMenuInstance = pauseMenu.GetPauseMenuObject();
        componentsToPause = pauseMenu.GetComponentsToPause();
        rigidbody2Ds = pauseMenu.GetRigidbody2Ds();
    }
    public void UnPauseGame()//tied to button in the canvas of the level
    {
        //Debug.Log("unpause was pressed");
        foreach (MonoBehaviour toUnPause in componentsToPause)//unpause all gameobjects
        {
            toUnPause.enabled = true;
        }
        foreach (Rigidbody2D toUnPause in rigidbody2Ds)
        {
            toUnPause.bodyType = RigidbodyType2D.Dynamic;
        }
        componentsToPause.Clear();//clear list 
        Destroy(pauseMenuInstance);//get rid of recently instantiated pause menu
        pauseMenu.GameUnpause();
    }
}
