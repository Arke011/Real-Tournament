using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField]TMP_Text ammoText;
    [SerializeField]TMP_Text healthText;

    public Weapon weapon;
    public Health HP;


    void Start()
    {
        UpdateUI();
        weapon.onShoot.AddListener(UpdateUI);
        HP.onDamage.AddListener(UpdateUI);
    }

    void UpdateUI()
    {
        ammoText.text = weapon.clipAmmo + "/" + weapon.ammo;
        healthText.text = HP.hp.ToString();
    }

}
