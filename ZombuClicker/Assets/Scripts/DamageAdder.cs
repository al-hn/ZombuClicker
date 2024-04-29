using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAdder : Item
{
    public Weapon weapon;
    public int quantity = 0;

    public void Start()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
    }

    public override void Apply()
    {
        weapon.damage = weapon.damage + 5;
    }
}
