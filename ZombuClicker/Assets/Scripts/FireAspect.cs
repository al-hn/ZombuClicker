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
    }

    public override void Apply()
    {
        InvokeRepeating("Fire", 3.0f, 3.0f);
    }

    public async void Fire()
    {
        if (weapon.hitCount % 5 == 0)
        {
            for (int i = 0; i < 6; i++)
            {
                weapon.Attack();
                await Task.Delay((int)(1.0f * 1000));
            }
            weapon.hitCount = 1;
        }
    }
}
