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

public class Zombie : MonoBehaviour
{
    public bool isAlive = true;
    public BaseHPValue baseHPValue;
    public float damageDuration = 0.2f;
    public TextMeshProUGUI CoinsObject;
    public GameObject DamageOverlay;
    [SerializeField] public int health = 100;
    [SerializeField] public int armor = 0;
    [SerializeField] public float zombieAttackCooldown = 3.0f;
    [SerializeField] public float RespawnCooldown = 1.0f;
    [SerializeField] public int damage = 1;
    [SerializeField] public int CoinsBalance = 0;
    [SerializeField] public int HPRegenBase = 3;
    public FlashEffect fleff;
    public NightAndDay nad;
    public GameObject deathscreen;

    void Start()
    {
        InvokeRepeating("AttackBase", zombieAttackCooldown, zombieAttackCooldown);
        baseHPValue = GameObject.Find("Base HP Text").GetComponent<BaseHPValue>();
        nad = GameObject.Find("Time").GetComponent<NightAndDay>();
        fleff = GetComponent<FlashEffect>();
        AttackBase();
    }

    public void AttackBase()
    {
        if (isAlive)
        {
            if (baseHPValue.Armor > 0)
            {
                baseHPValue.Armor = baseHPValue.Armor - damage;
                DamageEffect();
            }
            else if (baseHPValue.Armor == 0)
            {
                if (baseHPValue.BaseHealth > 0)
                {
                    baseHPValue.BaseHealth = baseHPValue.BaseHealth - damage;
                    DamageEffect();
                }
                else if (baseHPValue.Armor == 0 && baseHPValue.BaseHealth == 0)
                {
                    deathscreen.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            Debug.Log("Zombie is dead");
        }

    }

    public void Die()
    {
        isAlive = false;
        gameObject.SetActive(false);
        Debug.Log("Zombie Is Killed");
        DropCoin();
        HpHealAfterKillZombie();
    }

    public void Spawn()
    {
        if (nad.Day.gameObject.active)
        {
            gameObject.SetActive(true);
            fleff.img.material = fleff.originalMat;
            DefaultZombie();
            isAlive = true;
        }
        else
        {
            gameObject.SetActive(true);
            RollZombie();
            isAlive = true;
        }
    }

    public void DropCoin()
    {
        int CountCoins = Random.Range(1, 5);
        CoinsBalance = CoinsBalance + CountCoins;
    }

    void Update()
    {
        CoinsObject.text = $"{CoinsBalance}";
    }

    public void HpHealAfterKillZombie()
    {
        int HealHPBase = Random.Range(1, HPRegenBase);
        baseHPValue.BaseHealth = baseHPValue.BaseHealth + HealHPBase;
    }

    public void ChangeToBoss()
    {
        damage = baseHPValue.BaseHealth;
        health = 5000;
        CoinsBalance = CoinsBalance + 300;
        zombieAttackCooldown = 30.0f;
    }

    public void ZombieWithArmor()
    {
        damage = 50;
        health = 200;
        armor = 300;
        zombieAttackCooldown = 3.0f;
        CoinsBalance = CoinsBalance + 150;
    }

    public void SpeedZombie()
    {
        damage = 1;
        zombieAttackCooldown = 0.3f;
        health = 100;
        CoinsBalance = CoinsBalance + 100;
    }

    public void DefaultZombie()
    {
        health = 100;
        armor = Random.Range(0, 60);
        zombieAttackCooldown = 3.0f;
        damage = Random.Range(1, 5);
    }

    public void RollZombie()
    {
        float[] weights = { 0.4f, 0.3f, 0.2f, 0.1f };
        float totalWeight = 0f;
        foreach (float weight in weights)
        {
            totalWeight = totalWeight + weight;
        }

        float randVal = Random.Range(0f, totalWeight);
        if (randVal < weights[0])
        {
            DefaultZombie();
            Debug.Log("Default.");
        }
        else if (randVal < weights[0] + weights[1])
        {
            ZombieWithArmor();
            Debug.Log("Zombie w/armor is spawned");
        }
        else if (randVal < weights[0] + weights[1] + weights[2])
        {
            SpeedZombie();
            Debug.Log("Speed zombie is spawned");
        }
        else
        {
            ChangeToBoss();
            Debug.Log("Unlucky. Boss is spawned");
        }

    }
    public void DamageEffect()
    {
        ShowDamageIndicator();
        CancelInvoke("HideDamageIndicator"); //<--Resets timer if hit before indicator is hidden.
        Invoke("HideDamageIndicator", damageDuration);
    }

    public void ShowDamageIndicator()
    {
        DamageOverlay.SetActive(true);
    }

    public void HideDamageIndicator()
    {
        DamageOverlay.SetActive(false);
    }
}