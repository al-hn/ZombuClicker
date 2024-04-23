using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Zombie : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] public float zombieAttackCooldown = 3.0f;

    void Start()
    {
        InvokeRepeating("AttackBase", zombieAttackCooldown, zombieAttackCooldown);
    }

    public void AttackBase()
    {
        Debug.Log("Zombie Attacked Base!");
    }

    public void Die()
    {
        Debug.Log("Zombie Is Killed");
        Destroy(gameObject);
    }
}
