using Unity.VisualScripting;
using UnityEngine;

public class ButtonTurretSender : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;  // Datos de la torreta que se enviarán al StoreManager


    public void OnButtonClick()
    {
        TileEvents.SetTurret(turretPrefab.GetComponent<Turret>());
    }
}
