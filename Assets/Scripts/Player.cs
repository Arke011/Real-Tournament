using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Weapon weapon;
    public Health HP;
    public LayerMask weaponLayer;
    public GameObject grabTXT;
    public Transform hand;
    public UnityEvent<Weapon> onWeaponChange = new UnityEvent<Weapon>();
    


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HP.Damage(20);
        }

    }

    void Update()
    {
        var cam = Camera.main.transform;
        var collided = Physics.Raycast(cam.position, cam.forward, out var hit, 2f, weaponLayer);
        grabTXT.SetActive(collided);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (weapon == null && collided)
            {
                
                Grab(hit.collider.gameObject);
            }
            else
            {
                Drop();
            }
        }

        if (weapon == null) return;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onRightClick.Invoke();
        }

        // manual shooting
        if (!weapon.isAutomatic && Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }
        // automatic shooting
        if (weapon.isAutomatic && Input.GetKey(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }
        weapon.fireCooldown -= Time.deltaTime;
    }

    public void Grab(GameObject gun)
    {
        if (weapon != null) Drop();

        weapon = gun.GetComponent<Weapon>();
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.GetComponent<BoxCollider>().enabled = false;
        weapon.transform.position = hand.position;
        weapon.transform.rotation = hand.rotation;
        weapon.transform.parent = hand;
        onWeaponChange.Invoke(weapon);

    }

    public void Drop()
    {
        if (weapon == null) return;

        Debug.Log("Dropping weapon");

        weapon.GetComponent<Rigidbody>().isKinematic = false;
        weapon.GetComponent<BoxCollider>().enabled = true;
        weapon.transform.parent = null;
        weapon = null;
        onWeaponChange.Invoke(null);

        


    }

}
