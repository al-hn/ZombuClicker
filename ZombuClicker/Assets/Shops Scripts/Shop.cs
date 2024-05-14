using System;
using System.Collections;
using System.Collections.Generic;
// using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Threading.Tasks;
using RandomUnity = UnityEngine.Random;
using RandomSystem = System.Random;
using TMPro;
// using Unity.UI;
using UnityEngine.UI;
using YG;

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
    public SoundEffectsPlayer sfxPlayer;
    // [SerializeField] public Button BuyCoinsButton;
    public CloudSaving cloudSaving;
    public BaseHPValue baseHPValue;

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        // YandexGame.GetDataEvent += GetData;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
        // YandexGame.GetDataEvent -= GetData;
    }

    // public async void GetData()
    // {
    //     while(!YandexGame.SDKEnabled)
    //     {
    //         await Task.Delay(200);
    //     }
    //     await Task.Delay(100);
    // }

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
        FirstItemBoostText = GameObject.Find("dmgAdderTier").GetComponent<TextMeshProUGUI>();
        AcCost = GameObject.Find("acCostValue").GetComponent<TextMeshProUGUI>();
        AcTier = GameObject.Find("acTierValue").GetComponent<TextMeshProUGUI>();
        DmgAdderCost = GameObject.Find("dmgAdderCostValue").GetComponent<TextMeshProUGUI>();
        sfxPlayer = GameObject.Find("Canvas").GetComponent<SoundEffectsPlayer>();
        // BuyCoinsButton.onClick.AddListener(delegate { ExampleOpenRewardedAd(1); });
        cloudSaving = GameObject.Find("CloudSavings").GetComponent<CloudSaving>();
        baseHPValue = GameObject.Find("Base HP Text").GetComponent<BaseHPValue>(); 
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
                sfxPlayer.coinSound();
                cloudSaving.MySave();

                DmgAdderCost.text = $"{dmgAdder.price}";
                FirstItemBoostText.text = $"{dmgAdder.quantity}.";
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
            sfxPlayer.errorSound();
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
                sfxPlayer.coinSound();
                vamp.isOwned = true;
                vamp.Apply();
                cloudSaving.MySave();
            }
            else
            {
                youDontHaveObj.SetActive(true);
                sfxPlayer.errorSound();
            }
        }
    }

    public void BuyShield()
    {
        if (zombie.CoinsBalance >= baseShield.price)
        {
            zombie.CoinsBalance = zombie.CoinsBalance - baseShield.price;
            sfxPlayer.coinSound();
            baseShield.isOwned = true;
            baseShield.Apply();
            cloudSaving.MySave();
        }
        else
        {
            youDontHaveObj.SetActive(true);
            sfxPlayer.errorSound();
        }
    }

    public void BuyHealer()
    {
        if (zombie.CoinsBalance >= heal.price)
        {
            zombie.CoinsBalance = zombie.CoinsBalance - heal.price;
            sfxPlayer.coinSound();
            heal.isOwned = true;
            heal.Apply();
            cloudSaving.MySave();
        }
        else
        {
            youDontHaveObj.SetActive(true);
            sfxPlayer.errorSound();
        }
    }

    public void BuyFire()
    {
        if (fireAspect.isOwned == true)
        {
            Debug.Log("item is already owned.");
        }
        else
        {
            if (zombie.CoinsBalance >= fireAspect.price)
            {
                zombie.CoinsBalance = zombie.CoinsBalance - fireAspect.price;
                sfxPlayer.coinSound();
                fireAspect.isOwned = true;
                fireAspect.Apply();
                cloudSaving.MySave();
            }
            else
            {
                youDontHaveObj.SetActive(true);
                sfxPlayer.errorSound();
            }
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
                    sfxPlayer.coinSound();
                    autoclicker.price = autoclicker.price + 70;
                    autoclicker.damage = autoclicker.damage + 7;
                    AcCost.text = $"{autoclicker.price}";
                    AcTier.text = $"{autoclicker.quantity}";

                    FirstItemBoostText.text = $"boost: {autoclicker.quantity}.";
                    Debug.Log($"autoclicker quantity: {autoclicker.quantity}.");
                    autoclicker.Apply();
                    cloudSaving.MySave();
                }
                else
                {
                    Debug.Log("You maxed out this item!");
                }
            }
            else
            {
                youDontHaveObj.SetActive(true);
                sfxPlayer.errorSound();
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
                sfxPlayer.coinSound();
                dmgDoubler.isOwned = true;
                dmgDoubler.Apply();
                cloudSaving.MySave();
            }
            else
            {
                youDontHaveObj.SetActive(true);
                sfxPlayer.errorSound();
            }
        }
    }

    public void BuyCoins()
    {
        ExampleOpenRewardedAd(1);
        cloudSaving.MySave();
    }

    public void ExampleOpenRewardedAd(int id)
    {
        YandexGame.RewVideoShow(id);
        Debug.Log("RewVideoSHow WORKING");
    }

    void Rewarded(int id)
    {
        if (id == 1)
        {
            zombie.CoinsBalance = zombie.CoinsBalance + 50;
        }
        else if (id == 2)
        {
            Revive();
        }
    }
    
    public void Revive()
    {
        ExampleOpenRewardedAd(2);
        baseHPValue.BaseHealth = 100;
        cloudSaving.MySave();
    }
}