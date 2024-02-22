using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class health : MonoBehaviour
{

    public UnityEvent onDie;
    public UnityEvent onDamage;

    public int Hp;
    public int MaxHealth;

    void Update()
    {
        if (Hp == 0) Hp = MaxHealth;
    }

    public void Damage(int damage)
    {
        Hp -= damage;
        onDamage.Invoke();
        if (Hp <= 0)
        {
            Die();
            onDie.Invoke();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
