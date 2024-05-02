using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FireAspect : Item
{
    public Weapon weapon;

    public void Start()
    {
        weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        Apply();
    }

    public override void Apply()
    {
        if (isOwned == true)
        {
            Fire();
        }
    }

    public async void Fire()
    {
        for (int i = 0; i < 5; i++)
        {
            weapon.Attack();
            await Task.Delay((int)(1.0f * 1000));
        }
    }
}
