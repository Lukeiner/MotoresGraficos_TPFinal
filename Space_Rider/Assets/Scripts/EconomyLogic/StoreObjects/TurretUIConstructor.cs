using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    [SerializeField] private RawImage turretSpriteRenderer;
    

    void Start()
    {

    }


    public void ConstructTurretUI(GameObject uiElement, TurretStoreData turretData) {


        // Asignar los datos de la torreta a las variables locales
        turretName = turretData.turretName;
        cost = turretData.cost;
        sprite = turretData.sprite;
        turretPrefab = turretData.turretPrefab;
        
        turretNameText = uiElement.transform.Find("name").GetComponentInChildren<TextMeshProUGUI>();

        priceText = uiElement.transform.Find("price").GetComponentInChildren<TextMeshProUGUI>();
        turretSpriteRenderer = uiElement.transform.Find("RawImage").GetComponentInChildren<RawImage>();

        // Asignar el prefab de la torreta al ButtonTurretSender
        buttonSender = uiElement.GetComponent<ButtonTurretSender>();
        if (buttonSender != null) {
            buttonSender.GetType().GetField("turretPrefab", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(buttonSender, turretPrefab);
            buttonSender.GetType().GetField("cost", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(buttonSender, cost);
        }

        // Actualizar la UI con los datos de la torreta
        UpdateDataInTheUI();

    }
    private void UpdateDataInTheUI()
    {
        turretNameText.text = turretName;
        priceText.text = cost.ToString() + " $";
        turretSpriteRenderer.texture = sprite.texture;
    }



}
