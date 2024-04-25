using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Threading.Tasks;



public class Zombie : MonoBehaviour
{
    public bool isAlive = true;
    public BaseHPValue baseHPValue;
    public GameObject ZombiePrefab;
    [SerializeField] public int health = 100;
    [SerializeField] public float zombieAttackCooldown = 3.0f;
    [SerializeField] public float RespawnCooldown = 1.0f;
    [SerializeField] public int damage = 1;
    [SerializeField] public GameObject DropCoins;
    [SerializeField] private GameObject Zombu;

    void Start()
    {
        InvokeRepeating("AttackBase" , zombieAttackCooldown ,zombieAttackCooldown );
        baseHPValue = GameObject.Find("Base HP Text").GetComponent<BaseHPValue>();
        
        
        
    }

    public void AttackBase()
    {   
        if(baseHPValue.BaseHealth >=0 ){
            baseHPValue.BaseHealth = baseHPValue.BaseHealth - damage;

        }
        else{
            Debug.Log("Ты сдох");
        }
        // baseHPValue.BaseHealth = baseHPValue.BaseHealth - damage; 
        // Debug.Log("Мы атакавали");
        // if(baseHPValue.BaseHealth <= 0){
        //     Debug.Log("База разрушена");
        // }

    }

    public void Die()
    {
        isAlive = false;
        gameObject.SetActive(false);
        Debug.Log("Zombie Is Killed");
        
        
        
    
    }
    public void Spawn(){
         
         gameObject.SetActive(true);
         health = 100;
         isAlive = true;
         
         
    }

    private void DropCoin(){
         
    }
  
}
