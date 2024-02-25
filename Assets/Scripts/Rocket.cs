using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20f;
    public GameObject explosionPrefab;



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
        var Health = other.gameObject.GetComponent<Health>();
        if (Health != null)
        {
            Health.Damage(10);
        }
        Destroy(gameObject);
        //transform.forward = other.contacts[0].normal;
        if(explosionPrefab != null)Instantiate(explosionPrefab, transform.position, transform.rotation);
    }


}
