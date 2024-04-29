using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

public class Autoclicker : Item
{
    public Zombie zombie;

    public void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
    }

    public override void Apply()
    {
        InvokeRepeating("autoclick", 1.0f, 1.0f);
    }

    public async void autoclick()
    {
        if(zombie.health > 0) zombie.health = zombie.health - 1;
        else
        {
            zombie.Die();
            await Task.Delay((int)(1.0f * 1000));
            zombie.Spawn();
        } 
    }

}