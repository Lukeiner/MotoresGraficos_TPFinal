using UnityEngine;
using TMPro;

public class TurretUIConstructor : MonoBehaviour
{
    [Header("Turret Data")]
    [SerializeField] private string turretName;  
    [SerializeField] private int cost;
    [SerializeField] private Sprite sprite;
    [SerializeField] private GameObject turretPrefab;
    [SerializeField] private ButtonTurretSender buttonSender;  // Referencia al componente que enviará el mensaje al StoreManager

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI turretNameText;  
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private SpriteRenderer turretSpriteRenderer;
    

    void Start()
    {
        turretNameText.text = turretName;
        priceText.text = cost.ToString() + " $";
        turretSpriteRenderer.sprite = sprite;
    }


}
