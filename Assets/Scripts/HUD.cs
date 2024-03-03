using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]TMP_Text ammoText;
    [SerializeField]TMP_Text healthText;

    
    public Player player;
    Weapon weapon;
    public Health HP;


    void Start()
    {
        UpdateUI(); 

        
                          
        HP.onDamage.AddListener(UpdateUI);
        player.onWeaponChange.AddListener(UpdateCurrentWeapon);
    }

    public void UpdateUI()
    {
        if (weapon == null)
        {
            ammoText.text = "No Weapon";
        }
        else
        {
            ammoText.text = weapon.clipAmmo + "/" + weapon.ammo;
        }

        healthText.text = HP.hp.ToString();
    }

    public void UpdateCurrentWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
        UpdateUI();
    }

    void Update()
    {
        
        if (weapon != null)
        {
            weapon.onShoot.AddListener(UpdateUI);
            weapon.onReload.AddListener(UpdateUI);
            
        }

        
    }



}
