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
using UnityEngine.UI;

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
    [SerializeField] public TextMeshProUGUI DmgAdderCost;
    [SerializeField] public TextMeshProUGUI FirstItemBoostText;
    [SerializeField] public TextMeshProUGUI AcCost;
    [SerializeField] public TextMeshProUGUI AcTier;

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
        FirstItemBoostText = GameObject.Find("Tier DamageAdder").GetComponent<TextMeshProUGUI>();
        AcCost = GameObject.Find("autoclicker_cost").GetComponent<TextMeshProUGUI>();
        AcTier = GameObject.Find("autoclicker_tier").GetComponent<TextMeshProUGUI>();
        DmgAdderCost = GameObject.Find("dmgadder_cost").GetComponent<TextMeshProUGUI>();
    }

    public void DamageFromZombieplusone()
    {
        if (zombie.CoinsBalance >= dmgAdder.price)
        {
            if (dmgAdder.quantity < 100000)
            {
                dmgAdder.quantity = dmgAdder.quantity + 1;
                zombie.CoinsBalance = zombie.CoinsBalance - dmgAdder.price;
                dmgAdder.price = dmgAdder.price + 25;

                DmgAdderCost.text = $"Cost: {dmgAdder.price}";
                FirstItemBoostText.text = $"Tier: {dmgAdder.quantity}.";
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
                if (autoclicker.quantity < 100000)
                {
                    autoclicker.quantity = autoclicker.quantity + 1;
                    zombie.CoinsBalance = zombie.CoinsBalance - autoclicker.price;
                    autoclicker.price = autoclicker.price + 70;
                    autoclicker.damage = autoclicker.damage + 7;
                    AcCost.text = $"Cost: {autoclicker.price}";
                    AcTier.text = $"Tier: {autoclicker.quantity}";

                    FirstItemBoostText.text = $"boost: {autoclicker.quantity}.";
                    Debug.Log($"autoclicker quantity: {autoclicker.quantity}.");
                    autoclicker.Apply();
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
