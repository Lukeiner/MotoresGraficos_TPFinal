using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 2f;
    public float waitTime = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    System.Collections.IEnumerator FadeIn()
    {
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeGroup.alpha = time / fadeDuration;
            yield return null;
        }

        fadeGroup.alpha = 1;

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene("MainMenuScene");
    }
}