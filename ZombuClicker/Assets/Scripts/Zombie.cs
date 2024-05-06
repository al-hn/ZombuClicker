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
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class Zombie : MonoBehaviour
{
    public bool isAlive = true;
    public BaseHPValue baseHPValue;
    public float damageDuration = 0.2f;
    public TextMeshProUGUI CoinsObject;
    public GameObject DamageOverlay;
    [SerializeField] public int defaultZombuHealth = 100;
    [SerializeField] public int currentHealth;
    [SerializeField] public int armor = 0;
    [SerializeField] public float zombieAttackCooldown = 3.0f;
    [SerializeField] public float RespawnCooldown = 1.0f;
    [SerializeField] public int damage = 1;
    [SerializeField] public int CoinsBalance = 0;
    [SerializeField] public int HPRegenBase = 3;
    [SerializeField] public int zwaHealth = 200;
    [SerializeField] public int sZombie = 150;
    [SerializeField] public int jnbHealth = 10000;
    [SerializeField] public int jnzwaHealth = 500;
    [SerializeField] public int jnszHealth = 600;
    public FlashEffect fleff;
    public NightAndDay nad;
    public GameObject deathscreen;
    public int CountCoins;

    void Start()
    {
        InvokeRepeating("AttackBase", zombieAttackCooldown, zombieAttackCooldown);
        baseHPValue = GameObject.Find("Base HP Text").GetComponent<BaseHPValue>();
        nad = GameObject.Find("Time").GetComponent<NightAndDay>();
        fleff = GetComponent<FlashEffect>();
        currentHealth = defaultZombuHealth;
        InvokeRepeating("UpgradeZombie", nad.ColdownDays, nad.ColdownDays);
        InvokeRepeating("UpgradeDrop", nad.ColdownDays*2, nad.ColdownDays*2);
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
        // Debug.Log("Zombie Is Killed");
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
            currentHealth = defaultZombuHealth;
            isAlive = true;
        }
        else if (nad.judgment_night.gameObject.active)
        {
            gameObject.SetActive(true);
            RollZombieInJudgment_night();
            isAlive = true;
        }
        else
        {
            gameObject.SetActive(true);
            RollZombie();
            isAlive = true;
        }
        // gameObject.SetActive(true);
        // fleff.img.material = fleff.originalMat;
        // // DefaultZombie();
        // currentHealth = defaultZombuHealth;
        // isAlive = true;
    }

    public void DropCoin()
    {
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

    public void ZombieWithArmor()
    {
        damage = 15;
        CoinsBalance = CoinsBalance + 50;
        // currentHealth = zwaHealth;
    }

    public void SpeedZombie()
    {
        damage = 10;
        CoinsBalance = CoinsBalance + 30;
        CountCoins = Random.Range(2, 7);
        // currentHealth = sZombie;
    }

    public void DefaultZombie()
    {
        zombieAttackCooldown = 3.0f;
        damage = Random.Range(1, 5);
        CountCoins = Random.Range(2, 7);
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
            currentHealth = defaultZombuHealth;
            Debug.Log("DEFAULT");
        }
        else if (randVal < weights[0] + weights[1])
        {
            SpeedZombie();
            currentHealth = sZombie;
            Debug.Log("speed ZOMBIE night");
        }
        else if (randVal < weights[0] + weights[1] + weights[2])
        {
            ZombieWithArmor();
            currentHealth = zwaHealth;
            Debug.Log("Armor ZOMBIE night");
        }
    }

    public void RollZombieInJudgment_night()
    {
        float[] weights = { 0.4f, 0.3f, 0.1f };
        float totalWeight = 0f;
        foreach (float weight in weights)
        {
            totalWeight = totalWeight + weight;
        }

        float randVal = Random.Range(0f, totalWeight);
        if (randVal < weights[0] + weights[1])
        {
            SpeedZombieInJudgment_night();
            currentHealth = jnszHealth;
            Debug.Log("ARMOR ZOMBIE jn");
        }
        else if (randVal < weights[0] + weights[1] + weights[2])
        {
            ZombieWithArmorInJudgment_night();
            currentHealth = jnzwaHealth;
            Debug.Log("SPEED ZOMBIE jn");
        }
        else
        {
            ChangeToBossInJudgment_night();
            currentHealth = jnbHealth;
            Debug.Log("BOSS jn");
        }

    }

    public void ChangeToBossInJudgment_night()
    {
        damage = baseHPValue.BaseHealth + 1;
        CoinsBalance = CoinsBalance + 500;
        // currentHealth = jnbHealth;
    }

    public void ZombieWithArmorInJudgment_night()
    {
        damage = 20;
        armor = 1500;
        zombieAttackCooldown = 3.0f;
        CoinsBalance = CoinsBalance + 100;
        // currentHealth = jnzwaHealth;
    }

    public void SpeedZombieInJudgment_night()
    {
        damage = 15;
        CoinsBalance = CoinsBalance + 70;
        // currentHealth = jnszHealth;
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

    public void UpgradeZombie()
    {
        defaultZombuHealth = defaultZombuHealth + 5;
        zwaHealth = zwaHealth + 15;
        sZombie = sZombie + 10;
        jnbHealth = jnbHealth + 600;
        jnzwaHealth = jnzwaHealth + 70;
        jnszHealth = jnszHealth + 50;
    }
    
    public void UpgradeDrop()
    {
        CoinsBalance =+ 100;
        CoinsBalance =+ 100;
    }
}