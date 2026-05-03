using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioManager : MonoBehaviour
{
    private static MenuAudioManager instance;
    private AudioSource musicSource;
    private AudioSource sfxSource;

    [Header("SFX")]
    public AudioClip clickSound;
    public AudioClip hoverSound;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // 🔥 Buscar AudioSources en los hijos (Music y SFX)
        Transform music = transform.Find("Music");
        Transform sfx = transform.Find("SFX");

        if (music != null)
            musicSource = music.GetComponent<AudioSource>();

        if (sfx != null)
            sfxSource = sfx.GetComponent<AudioSource>();

        if (musicSource == null || sfxSource == null)
        {
            Debug.LogError("Faltan AudioSources en los objetos 'Music' o 'SFX'");
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        float music = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        SetMusicVolume(music);
        SetSFXVolume(sfx);

        UpdateMusic(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateMusic(scene.name);
    }

    void UpdateMusic(string sceneName)
    {
        if (sceneName == "MainMenuScene" || sceneName == "MainMenuOptionsScene")
        {
            if (musicSource != null && !musicSource.isPlaying)
            {
                musicSource.loop = true;
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource != null)
                musicSource.Stop();
        }
    }

    // 🔊 CLICK
    public void PlayClick()
    {
        if (sfxSource != null && clickSound != null && !sfxSource.mute)
        {
            sfxSource.PlayOneShot(clickSound);
        }
    }

    // 🖱️ HOVER
    public void PlayHover()
    {
        if (sfxSource != null && hoverSound != null && !sfxSource.mute)
        {
            sfxSource.PlayOneShot(hoverSound);
        }
    }

    // 🎵 VOLUMEN MÚSICA
    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;

            if (volume <= 0.01f)
                musicSource.mute = true;
            else
                musicSource.mute = false;
        }

        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    // 🔊 VOLUMEN SFX
    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;

            if (volume <= 0.01f)
                sfxSource.mute = true;
            else
                sfxSource.mute = false;
        }

        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}