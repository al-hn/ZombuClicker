using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Threading.Tasks;
using RandomUnity = UnityEngine.Random;
using RandomSystem = System.Random;
using TMPro;
using Unity.UI;

public class Shop : MonoBehaviour
{
    public Weapon weapon;
    public Zombie zombie;
    [SerializeField] public int addDamageFromFirstItems = 1;
    [SerializeField] public int RegenBase = 1;
    public BaseShield baseShield;
    public GameObject youDontHaveObj;
    public Heal heal;
    public FireAspect fireAspect;
    public Autoclicker autoclicker;
    public DamageDoubler dmgDoubler;
    
    void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        baseShield = GameObject.Find("BaseShield").GetComponent<BaseShield>();
        heal = GameObject.Find("Heal").GetComponent<Heal>();
        fireAspect = GameObject.Find("FireAspect").GetComponent<FireAspect>();
        autoclicker = GameObject.Find("Autoclicker").GetComponent<Autoclicker>();
        dmgDoubler = GameObject.Find("DamageDoubler").GetComponent<DamageDoubler>();
    }

    public void DamageFromZombieplusone(){
        weapon.damage = weapon.damage + addDamageFromFirstItems;
    }

    public void HPRegenBaseVoidd()
    {
        zombie.HPRegenBase = zombie.HPRegenBase + RegenBase;
    }

    public void BuyShield()
    {
        baseShield.price = 150;

        if (zombie.CoinsBalance >= baseShield.price)
        {
            zombie.CoinsBalance = zombie.CoinsBalance - baseShield.price;
            baseShield.isOwned = true;
            baseShield.Apply();
        }
        else
        {
            youDontHaveObj.SetActive(true);
        }
    }

    public void BuyHealer()
    {
        if (zombie.CoinsBalance >= heal.price)
        {
            zombie.CoinsBalance = zombie.CoinsBalance - heal.price;
            heal.isOwned = true;
            heal.Apply();
        }
        else
        {
            youDontHaveObj.SetActive(true);
        }
    }

    public void BuyFire()
    {
        if (zombie.CoinsBalance >= fireAspect.price)
        {
            zombie.CoinsBalance = zombie.CoinsBalance - fireAspect.price;
            fireAspect.isOwned = true;
            fireAspect.Apply();
        }
        else
        {
            youDontHaveObj.SetActive(true);
        }
    }

    public void BuyAutoclicker()
    {
        if (zombie.CoinsBalance >= autoclicker.price)
        {
            zombie.CoinsBalance = zombie.CoinsBalance - autoclicker.price;
            autoclicker.isOwned = true;
            autoclicker.Apply();
        }
        else
        {
            youDontHaveObj.SetActive(true);
        }
    }

    public void BuyDmgDoubler()
    {
        if (zombie.CoinsBalance >= dmgDoubler.price)
        {
            zombie.CoinsBalance = zombie.CoinsBalance - dmgDoubler.price;
            dmgDoubler.isOwned = true;
            dmgDoubler.Apply();
        }
        else
        {
            youDontHaveObj.SetActive(true);
        }
    }

}
