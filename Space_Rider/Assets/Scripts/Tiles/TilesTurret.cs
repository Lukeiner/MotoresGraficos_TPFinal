using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TilesTurret : Tiles, IPointerClickHandler
{
    
    [SerializeField] bool thereIsATurret;
    [SerializeField] Turret actualTurret;
    [SerializeField] int level =0;
    event System.Action<TilesTurret> onClick;
    event System.Action<TilesTurret> onOpenTurretMenu;

    void Start()
    {
        thereIsATurret=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetATurret(Turret turret)
    {
        if (thereIsATurret == false)
        {
            actualTurret = turret;
            thereIsATurret = true;
        }
    }

public void OnPointerClick(PointerEventData eventData)
    {
        
        if (!thereIsATurret)
        {
            level++;
            
            TileEvents.OnOpenTurretMenu?.Invoke(this);
            
        }
        else
        {
            
            TileEvents.OnTileClicked?.Invoke(this);
        }
    }
    private void OpenTurretMenu()
    {
        Debug.Log("Open turret menu");
    }
}
