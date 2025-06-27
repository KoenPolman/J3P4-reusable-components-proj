using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenuButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene(0);
    }
}
