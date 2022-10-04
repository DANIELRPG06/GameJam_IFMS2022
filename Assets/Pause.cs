using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject OptionsPainel;
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc foi pressionado");
            if(isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }   
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene("Jogo Teste");
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
         Time.timeScale = 0f;
        isGamePaused = true; 
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void OpenOptions()
    {
        pauseMenu.SetActive(false);
        OptionsPainel.SetActive(true);
    }
    
    public void CloseOptions()
    {
        pauseMenu.SetActive(true);
        OptionsPainel.SetActive(false);
    }
}
