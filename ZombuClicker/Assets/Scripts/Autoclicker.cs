using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

public class Autoclicker : Item
{
    public Zombie zombie;
    public int quantity;
    public int damage = 1;

    public void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
    }

    public override void Apply()
    {
        InvokeRepeating("autoclick", 1.0f, 1.0f);
    }

    public void autoclick()
    {
        if (zombie.currentHealth > 0) zombie.currentHealth = zombie.currentHealth - damage;
        else
        {
            zombie.Die();
            zombie.Spawn();
        }
    }

}