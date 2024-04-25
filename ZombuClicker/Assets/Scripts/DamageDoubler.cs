using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDoubler : Item
{
    public Weapon weapon;

    public void Start()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        Apply();
    }

    public override void Apply()
    {
        if (isOwned == true) weapon.damage = weapon.damage * 2;
    }
}
