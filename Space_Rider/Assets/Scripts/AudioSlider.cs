using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public bool isMusic; // ✔ checkbox en inspector

    private MenuAudioManager audioManager;
    private Slider slider;

    void Start()
    {
        audioManager = FindObjectOfType<MenuAudioManager>();
        slider = GetComponent<Slider>();

        if (audioManager == null)
        {
            Debug.LogError("No se encontró MenuAudioManager");
            return;
        }

        // Cargar valor guardado
        float value = isMusic 
            ? PlayerPrefs.GetFloat("MusicVolume", 0.5f)
            : PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        slider.SetValueWithoutNotify(value);

        // Conectar evento
        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float value)
    {
        if (isMusic)
            audioManager.SetMusicVolume(value);
        else
            audioManager.SetSFXVolume(value);
    }
}