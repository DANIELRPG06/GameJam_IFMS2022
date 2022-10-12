using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenuBut()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
