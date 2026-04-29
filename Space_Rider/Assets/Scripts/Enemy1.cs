using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Enemy: MonoBehaviour
{
    [Header("Stats")]
    protected int lifes;

    protected int damage;


    protected Vector3 target;
    protected bool arrived = false;

    void Start()
    {
        
    }

    //Getters y Setters de Vidas
    public void setLifes(int l) {

        lifes = l;

    }
    public int getLifes() {

        return lifes;
    }


    //Getters y Setters de Damage

    public void setDamage(int d)
    {
        damage = d;
    }
    public int getDamage()
    {
        return damage;
    }

    public void TakeDamage (int amount)
    {
        lifes = -amount;
        if (lifes <= 0) Die();
    }

    protected virtual void Die()
    {

        if (this == null) return;
        Destroy(gameObject);
    }

    protected virtual void ReachEnd()
    {
        if (this == null) return; // ya fue destruido
        Destroy(gameObject);
    }


    public void SetTarget(Vector3 t)
    {
        target = t;
    }



}
