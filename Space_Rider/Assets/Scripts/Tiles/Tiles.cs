using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField] bool thereIsATurret;
    [SerializeField] Turret actualTurret;

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
    
}

