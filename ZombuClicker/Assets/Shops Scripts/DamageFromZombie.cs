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

public class DamageFromZombie : MonoBehaviour
{
    public Weapon weapon;
    public Zombie zombie;
    [SerializeField] public int addDamageFromFirstItems = 1;
    [SerializeField] public int RegenBase = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
    }

    // Update is called once per frame
   public void DamageFromZombieplusone(){
    weapon.damage = weapon.damage + addDamageFromFirstItems;
   }

   public void HPRegenBaseVoidd(){
    zombie.HPRegenBase = zombie.HPRegenBase + RegenBase;
   }
}
