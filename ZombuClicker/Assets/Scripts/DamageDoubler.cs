using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoubler : Item
{
    public Weapon weapon;

    public void Start()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
    }

    public override void Apply()
    {
        weapon.damage = weapon.damage * 2;
    }
}