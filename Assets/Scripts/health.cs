using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int Hp;
    public int MaxHealth;

    void Update()
    {
        if (Hp == 0) Hp = MaxHealth;
    }

    public void Damage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
