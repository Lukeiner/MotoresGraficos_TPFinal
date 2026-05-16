using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Display Settings")]
    public Toggle fullscreenToggle;

    void Start()
    {
        // Configura el toggle correctamente en cada escena
        if (fullscreenToggle != null)
        {
            fullscreenToggle.SetIsOnWithoutNotify(Screen.fullScreen);
            fullscreenToggle.onValueChanged.RemoveAllListeners();
            fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        }
        else
        {
            Debug.LogWarning("Fullscreen Toggle no asignado.");
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelectorScene");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("MainMenuOptionsScene");
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Debug.Log("Toggle cambiado: " + isFullscreen);

        if (isFullscreen)
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        else
            Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}