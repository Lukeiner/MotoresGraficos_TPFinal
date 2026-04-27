using UnityEngine;

public class Turret : MonoBehaviour
{
    public int level = 1;
    public float range = 5f;
    public int damage = 50;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Upgrade()
    {
       if (level == 1)
       {
           level = 2;
           range += 2f;
           damage += 25;
           Debug.Log("Turret upgraded to level 2");
       }
       else if (level == 2)
       {
           level = 3;
           range += 3f;
           damage += 50;
           Debug.Log("Turret upgraded to level 3");
       }
    }
}
