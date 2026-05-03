using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private MenuAudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<MenuAudioManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (audioManager != null)
            audioManager.PlayClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioManager != null)
            audioManager.PlayHover();
    }
}