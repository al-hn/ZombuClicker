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
    public BaseShield baseShield;
    public GameObject youDontHaveObj;
    public Heal heal;
    public FireAspect fireAspect;
    public Autoclicker autoclicker;
    public DamageDoubler dmgDoubler;
    public DamageAdder dmgAdder;
    public Vampirism vamp;
    
    void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        baseShield = GameObject.Find("BaseShield").GetComponent<BaseShield>();
        heal = GameObject.Find("Heal").GetComponent<Heal>();
        fireAspect = GameObject.Find("FireAspect").GetComponent<FireAspect>();
        autoclicker = GameObject.Find("Autoclicker").GetComponent<Autoclicker>();
        dmgDoubler = GameObject.Find("DamageDoubler").GetComponent<DamageDoubler>();
        dmgAdder = GameObject.Find("DamageAdder").GetComponent<DamageAdder>();
        vamp = GameObject.Find("Vampirism").GetComponent<Vampirism>();
    }

    public void DamageFromZombieplusone()
    {
        if (zombie.CoinsBalance >= dmgAdder.price)
        {
            if (dmgAdder.quantity < 5)
            {
                dmgAdder.quantity = dmgAdder.quantity + 1;
                Debug.Log($"dmgadder quantity: {dmgAdder.quantity}.");
                dmgAdder.Apply();
            }
            else
            {
                Debug.Log("You maxed out this item!");
            }
        }
        else
        {
            youDontHaveObj.SetActive(true);
        }

    }

    public void HPRegenBaseVoidd()
    {
        if (vamp.isOwned == true)
        {
            Debug.Log("item is already owned.");
        }
        else
        {
            if (zombie.CoinsBalance >= vamp.price)
            {
                zombie.CoinsBalance = zombie.CoinsBalance - vamp.price;
                vamp.isOwned = true;
                vamp.Apply();
            }
            else
            {
                youDontHaveObj.SetActive(true);
            }
        }
    }

    public void BuyShield()
    {
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
        if (autoclicker.isOwned == true)
        {
            Debug.Log("item is already owned.");
        }
        else
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
    }

    public void BuyDmgDoubler()
    {
        if (dmgDoubler.isOwned == true)
        {
            Debug.Log("item is already owned.");
        }
        else
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

}
