using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseShield : Item
{
    public BaseHPValue baseHPValue;

    public void Start()
    {
        baseHPValue = GameObject.Find("Base HP Text").GetComponent<BaseHPValue>();
    }

    public override void Apply()
    {
        if (isOwned == true) baseHPValue.Armor = baseHPValue.Armor + 100;
    }
}