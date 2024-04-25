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



public class Zombie : MonoBehaviour
{
    public bool isAlive = true;
    public BaseHPValue baseHPValue;
    public GameObject ZombiePrefab;
    public TextMeshProUGUI CoinsObject;
    [SerializeField] public int health = 100;
    [SerializeField] public float zombieAttackCooldown = 3.0f;
    [SerializeField] public float RespawnCooldown = 1.0f;
    [SerializeField] public int damage = 1;
    [SerializeField] public int CoinsBalance = 0;
    [SerializeField] public int HPRegenBase = 3;
    [SerializeField] private GameObject Zombu;

    void Start()
    {
        InvokeRepeating("AttackBase" , zombieAttackCooldown ,zombieAttackCooldown );
        baseHPValue = GameObject.Find("Base HP Text").GetComponent<BaseHPValue>();
    }

    public void AttackBase()
    {   
        if(baseHPValue.BaseHealth >=0)
        {
            baseHPValue.BaseHealth = baseHPValue.BaseHealth - damage;
        }
        else{
            Debug.Log("Ты сдох");
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
        gameObject.SetActive(true);
        health = 100;
        isAlive = true;
    }

    private void DropCoin()
    {
        int CountCoins = UnityEngine.Random.Range(1, 5);
        CoinsBalance = CoinsBalance + CountCoins;
    }
    
    void Update()
    {
        CoinsObject.text = $"{CoinsBalance}";
    }

    private void HpHealAfterKillZombie()
    {
        int HealHPBase = UnityEngine.Random.Range(1, HPRegenBase);
        baseHPValue.BaseHealth = baseHPValue.BaseHealth + HealHPBase;
    }
}
