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
using UnityEngine.UIElements;
using JetBrains.Annotations;
using System.IO;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    public UnityEngine.UI.Image imageComponent;
    public bool isAlive = true;
    public BaseHPValue baseHPValue;
    public float damageDuration = 0.2f;
    public TextMeshProUGUI CoinsObject;
    public GameObject DamageOverlay;
    // Zombie sprites
    [SerializeField] public Sprite DefaultZombieSprite;
    [SerializeField] public Sprite lvl2ZombieSprite;
    [SerializeField] public Sprite ArmorZombieSprite;
    [SerializeField] public Sprite BossZombieSprite;
    // Zombie GameeObject
    public GameObject speedZombie;
    public GameObject armorZombie;
    public GameObject bossZombie;
    
    [SerializeField] public int defaultZombuHealth = 100;
    [SerializeField] public int currentHealth;
    [SerializeField] public int armor = 0;
    [SerializeField] public int MinCoin = 2;
    [SerializeField] public int MaxCoin = 7;
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
    public SoundEffectsPlayer sfxPlayer;
    public CloudSaving cloudSaving;

    void Start()
    {
        imageComponent = GetComponent<UnityEngine.UI.Image>();
        InvokeRepeating("AttackBase", zombieAttackCooldown, zombieAttackCooldown);
        baseHPValue = GameObject.Find("Base HP Text").GetComponent<BaseHPValue>();
        nad = GameObject.Find("Time").GetComponent<NightAndDay>();
        fleff = GetComponent<FlashEffect>();
        currentHealth = defaultZombuHealth;
        InvokeRepeating("UpgradeZombie", nad.ColdownDays, nad.ColdownDays);
        InvokeRepeating("UpgradeDrop", nad.ColdownDays*2, nad.ColdownDays*2);
        sfxPlayer = GameObject.Find("Canvas").GetComponent<SoundEffectsPlayer>();
        cloudSaving = GameObject.Find("CloudSavings").GetComponent<CloudSaving>();

        // speedZombie = GameObject.Find("ранер зомби");
        // armorZombie = GameObject.Find("зомби брониносец");
        // bossZombie = GameObject.Find("зомби босс");

        speedZombie.transform.localPosition = gameObject.transform.localPosition;
        armorZombie.transform.localPosition = gameObject.transform.localPosition;
        bossZombie.transform.localPosition = gameObject.transform.localPosition;

        speedZombie.transform.localScale = gameObject.transform.localScale;
        armorZombie.transform.localScale = gameObject.transform.localScale;   
        bossZombie.transform.localScale = gameObject.transform.localScale;
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
                    sfxPlayer.errorSound();
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
        DropCoin();
        HpHealAfterKillZombie();
        isAlive = false;
        gameObject.SetActive(false);
        // Debug.Log("Zombie Is Killed");
    }

    public void Spawn()
    {
        // if (nad.Day.gameObject.active)
        // {
        //     gameObject.SetActive(true);
        //     fleff.img.material = fleff.originalMat;
        //     DefaultZombie();
        //     currentHealth = defaultZombuHealth;
        //     isAlive = true;
        // }
        // else if (nad.judgment_night.gameObject.active)
        // {
        //     gameObject.SetActive(true);
        //     RollZombieInJudgment_night();
        //     isAlive = true;
        // }
        // else
        // {
        //     gameObject.SetActive(true);
        //     RollZombie();
        //     isAlive = true;
        // }
        gameObject.SetActive(true);
        fleff.img.material = fleff.originalMat;
        DefaultZombie();
        currentHealth = defaultZombuHealth;
        isAlive = true;
    }

    public void DropCoin()
    {
        CoinsBalance = CoinsBalance + CountCoins;
        cloudSaving.MySave();
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
        imageComponent.sprite = ArmorZombieSprite;
        // armorZombie.SetActive(true);
        // gameObject.SetActive(false);
        // speedZombie.SetActive(false);
        // bossZombie.SetActive(false);
        damage = 15;
        CoinsBalance = CoinsBalance + 50;
        CountCoins = Random.Range(MinCoin, MaxCoin);
       
        cloudSaving.MySave();
    }

    public void SpeedZombie()
    {
        // armorZombie.SetActive(false);
        // gameObject.SetActive(false);
        // speedZombie.SetActive(true);
        // bossZombie.SetActive(false);

        imageComponent.sprite = lvl2ZombieSprite;
        damage = 10;
        CoinsBalance = CoinsBalance + 30;
        CountCoins = Random.Range(MinCoin, MaxCoin);
        
        cloudSaving.MySave();
    }

    public void DefaultZombie()
    {
       

        imageComponent.sprite = DefaultZombieSprite;
        zombieAttackCooldown = 3.0f;
        damage = Random.Range(1, 5);
        CountCoins = Random.Range(MinCoin, MaxCoin);
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
       

        sfxPlayer.jumpscare();
        imageComponent.sprite = BossZombieSprite;
        damage = baseHPValue.BaseHealth + 1;
        CoinsBalance = CoinsBalance + 500;
        CountCoins = Random.Range(MinCoin, MaxCoin);
        
        cloudSaving.MySave();
    }

    public void ZombieWithArmorInJudgment_night()
    {
        
        imageComponent.sprite = ArmorZombieSprite;
        damage = 20;
        armor = 1500;
        zombieAttackCooldown = 3.0f;
        CoinsBalance = CoinsBalance + 100;
        CountCoins = Random.Range(MinCoin, MaxCoin);
        
        cloudSaving.MySave();
    }

    public void SpeedZombieInJudgment_night()
    {
  

        imageComponent.sprite = lvl2ZombieSprite;
        damage = 15;
        CoinsBalance = CoinsBalance + 70;
        CountCoins = Random.Range(MinCoin, MaxCoin);
        
        cloudSaving.MySave();
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
        defaultZombuHealth = defaultZombuHealth + 10;
        zwaHealth = zwaHealth + 20;
        sZombie = sZombie + 15;
        jnbHealth = jnbHealth + 200;
        jnzwaHealth = jnzwaHealth + 70;
        jnszHealth = jnszHealth + 50;
        cloudSaving.MySave();
    }
    
    public void UpgradeDrop()
    {
        MaxCoin = MaxCoin + 3;
        MinCoin = MinCoin + 2;
        cloudSaving.MySave();
    }
}