using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Heal : Item
{
    public BaseHPValue baseHPValue;

    void Start()
    {
        baseHPValue = GameObject.Find("Base HP Text").GetComponent<BaseHPValue>();
        Apply();
    }

    public override void Apply()
    {
        if (isOwned == true)
        {
            HealBase();
        }
    }

    public void HealBase()
    {
        baseHPValue.BaseHealth = baseHPValue.BaseHealth + 30;
    }
}
