using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool isMapOpen { get; private set; } = false;
    [SerializeField]
    private GameObject Mapa;
    [SerializeField]
    private Player player;
    public bool isGamePaused = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject OptionsPainel;

    void Update()
    {
        if (Input.GetButtonDown("Map"))
        {
            isMapOpen = !isMapOpen;
            Mapa.SetActive(isMapOpen);
            if (isMapOpen)
            {
                AlertaInimigo();

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc foi pressionado");
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    void AlertaInimigo()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");
        // acha inimigo mais proximo
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = player.transform.position;
        foreach (GameObject go in inimigos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        closest.GetComponent<Inimigo>().AlertaPlayer(player.transform);
    }

    public void ResumeGame()
    {
        Debug.Log("Resume");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;

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
