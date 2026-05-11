using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool gamePaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
           {

            if (gamePaused)
            {
                Reanudar();
            }

            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void Pausar()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
        SceneManager.LoadScene(0);
    }
}
