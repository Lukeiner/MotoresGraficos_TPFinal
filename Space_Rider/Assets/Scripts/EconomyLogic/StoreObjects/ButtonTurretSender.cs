using Unity.VisualScripting;
using UnityEngine;

// ButtonTurretSender: solo emite intención
public class ButtonTurretSender : MonoBehaviour {
    [SerializeField] private GameObject turretPrefab;

    [SerializeField] private int cost;

    public void OnButtonClick() {
        Debug.Log($"Button clicked for turret: {turretPrefab.name} with cost: {cost}");
        GameManager.Instance.TryBuildTurret(turretPrefab, cost);
    }
}

