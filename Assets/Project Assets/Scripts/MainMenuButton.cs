using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart()
    {
        SceneManager.LoadScene("Jogo Teste");
    }

    public void MainMenuBut()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
