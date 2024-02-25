using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTPMod : MonoBehaviour
{
    public Health HP;
    float minX = -7f;
    float maxX = 8f;
    float minY = 0f;
    float maxY = 4f;
    float minZ = -6f;
    float maxZ = 6f;

    void Start()
    {
        
        HP = GetComponent<Health>();

        if (HP == null)
        {
            Debug.LogError("Uzdek health scripta ant enemy!!!!!!!!!");
        }
    }

    public void TeleportEnemy()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        

        
        transform.position = new Vector3(randomX, randomY, randomZ);

        HP.hp += 20;
    }
}
