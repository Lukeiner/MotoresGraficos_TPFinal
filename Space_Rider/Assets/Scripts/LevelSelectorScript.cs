using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // =========================
    // LEVELS
    // =========================

    public void Level1()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("lvl3");
    }

    // =========================
    // CUTSCENES
    // =========================

    public void Story1()
    {
        SceneManager.LoadScene("Cutscene1");
    }

    public void Story2()
    {
        SceneManager.LoadScene("Cutscene2");
    }

    public void Story3()
    {
        SceneManager.LoadScene("Cutscene3");
    }

    // =========================
    // BACK BUTTON
    // =========================

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}