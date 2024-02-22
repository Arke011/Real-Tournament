using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{

    public GameObject bulletPrefab;
    public int ammo;
    public int maxAmmo;
    public int clipAmmo;
    public int clipSize;
    public bool isReloading;
    public bool isAutomatic;
    public float fireInterval = 0.1f;
    public float fireCooldown;
    public float reloadTime = 2;
    public bool isShotgun;

    public UnityEvent onRightClick;

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
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            onRightClick.Invoke();
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
        if (clipAmmo == clipSize) return;

        

        isReloading = true;

        await new WaitForSeconds(3);

        

        isReloading = false;
        
        var ammoNeeded = Mathf.Min(clipSize - clipAmmo, ammo);
        ammo -= ammoNeeded;
        clipAmmo += ammoNeeded;

        Debug.Log("Ginklas paruostas veiksmui!");
    }
   
    public void Shoot()
    {
        if (isReloading) return;

        if (fireCooldown > 0) return;

        if (clipAmmo <= 0)
        {
            Debug.Log("You need to reload!!!!");
            return;

        }

        if (clipAmmo > 0)
        {
            if (isShotgun)
            {
                int pellets = 10;

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
            }

            Instantiate(bulletPrefab, transform.position, transform.rotation);
            fireCooldown = fireInterval;
            
        }
        clipAmmo--;
    }

    

}
