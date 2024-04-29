using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : Item
{
    public Zombie zombie;

    void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
    }

    override public void Apply()
    {
        zombie.HPRegenBase = zombie.HPRegenBase + 15;
    }
}
