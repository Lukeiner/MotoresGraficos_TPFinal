using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TilesTurret : Tiles, IPointerClickHandler
{
    
    [SerializeField] bool thereIsATurret;
    [SerializeField] Turret actualTurret;
    [SerializeField] int level = 0;


    void Start()
    {
        thereIsATurret=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clickkkkkk");
        if (!thereIsATurret)
        {
            TileEvents.SelectTile(this);
            TileEvents.OnOpenTurretMenu?.Invoke(this);        
        }
        else
        {
            Debug.Log("Open turret menu");

            TileEvents.SelectTile(this);
            TileEvents.OnTileClicked?.Invoke(this);
            
        }
    }

    public void SetATurretPublic(Turret turret)
    {
  
        actualTurret = turret;
        thereIsATurret = true;
    }
    public Turret GetActualTurret()
    {
        return actualTurret;
    }
}
