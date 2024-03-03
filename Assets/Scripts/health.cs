using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int hp;
    public int maxHp = 100;

    public bool shouldDestroy;

    public UnityEvent onDie;
    public UnityEvent onDamage;

    public GameObject deathEffect;
    public GameObject damageEffect;
    


    void Start()
    {
        if (hp == 0) hp = maxHp;
    }

    public void Damage(int damage)
    {
        
        hp -= damage;
        onDamage.Invoke();
        if (hp <= 0)
        {
            shouldDestroy = true;
            Die();
            
        }
        if (hp < 0)hp = 0;
        if (damageEffect != null)Instantiate(damageEffect, transform.position, Quaternion.identity);    
        onDie.Invoke();
    }

    public void Die()
    {

        if (shouldDestroy)Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        onDie.Invoke();




    }
}
