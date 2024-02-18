using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public int AmmoCount;
    public int maxAmmo;
    public bool isReloading;
    public bool isAutomatic;
    public float fireInterval = 0.1f;
    public float fireCooldown;
    public float reloadTime = 2;

    void Update()
    {
        if (!isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot(); 
            
        }
        if (isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Ginklas uztaisomas!");
            Reload();
        }
        fireCooldown -= Time.deltaTime;
    }

    async void Reload()
    {
        if (isReloading) return;
        isReloading = true;

        await new WaitForSeconds(3);

        isReloading = false;
        AmmoCount = maxAmmo;

        Debug.Log("Ginklas paruostas veiksmui!");
    }
   
    void Shoot()
    {
        if (isReloading) return;

        if (fireCooldown > 0) return;



        

        if (AmmoCount <= 0)
        {
            Debug.Log("You need to reload!!!!");

        }
        if (AmmoCount > 0)
        {
            fireCooldown = fireInterval;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
        AmmoCount--;
    }
}
