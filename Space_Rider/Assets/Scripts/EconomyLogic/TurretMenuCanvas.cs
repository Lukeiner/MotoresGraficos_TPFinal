using UnityEngine;

public class TurretMenuCanvas : MonoBehaviour
{
    [SerializeField] private GameObject turretMenuCanvas;
    [SerializeField] private float YHeight;

    void Start()
    {
        YHeight = turretMenuCanvas.GetComponent<RectTransform>().rect.height;
        turretMenuCanvas.transform.position = new Vector3(turretMenuCanvas.transform.position.x, turretMenuCanvas.transform.position.y -YHeight, turretMenuCanvas.transform.position.z);
        TileEvents.OnOpenTurretMenu += OpenTurretMenu;
        TileEvents.OnCloseTurretMenu += CloseTurretMenu;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OpenTurretMenu(TilesTurret tile)
    {
        Debug.Log("Open turret menu");
        turretMenuCanvas.SetActive(true);
        OpenMenuAnimation();
    }
    public void CloseTurretMenu()
    {
        CloseMenuAnimation();
    }
    private void OpenMenuAnimation()
    {
        LeanTween.moveY(turretMenuCanvas, 0, 0.5f).setEase(LeanTweenType.easeOutSine);
    }
    private void CloseMenuAnimation()
    {

        float moveTo  =turretMenuCanvas.transform.position.y - YHeight;
        LeanTween.moveY(turretMenuCanvas, moveTo , 0.5f).setEase(LeanTweenType.easeInSine).setOnComplete(() =>
        {
            turretMenuCanvas.SetActive(false);
        });
    }
}
