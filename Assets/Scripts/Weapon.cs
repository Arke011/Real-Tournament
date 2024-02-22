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
    public bool isShotgun;

    void Update()
    {
        if (!isShotgun && !isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot(); 
            
        }
        if (isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            
            Shoot();
        }

        if (isShotgun && Input.GetKeyDown(KeyCode.Mouse0))
        {

            Shotgun();
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

    void Shotgun()
    {
        if (isReloading) return;

        if (fireCooldown > 0) return;

        if (AmmoCount <= 0)
        {
            Debug.Log("You need to reload!!!!");
            return;
        }

        int pellets = 5;

        for (int i = 0; i < pellets; i++)
        {
            float spreadX = Random.Range(-5f, 5f);
            float spreadY = Random.Range(-5f, 5f);
            float spreadZ = Random.Range(-5f, 5f);

            Quaternion spreadRotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x + spreadX,
                transform.rotation.eulerAngles.y + spreadY,
                transform.rotation.eulerAngles.z + spreadZ
            );

            Instantiate(bulletPrefab, transform.position, spreadRotation);
        }

        fireCooldown = fireInterval;
        AmmoCount--;
    }

}
