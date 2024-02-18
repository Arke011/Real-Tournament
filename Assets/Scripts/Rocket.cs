using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20f;

    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void Start()
    {
        Destroy(gameObject, 3);
    }

    void OnCollisionEnter(Collision other)
    {
        var health = other.gameObject.GetComponent<health>();
        if (health != null)
        {
            health.Damage(10);
        }
        Destroy(gameObject);
    }


}
