using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Zombie zombie;
    [SerializeField] public int damage = 5;

    void Start()
    {
        zombie = GameObject.Find("Zombie").GetComponent<Zombie>();
    }

    public void Attack()
    {
        zombie.health = zombie.health - damage;
        Debug.Log("ZOMBU HEALTH: " + zombie.health);

        if (zombie.health <= 0)
        {
            zombie.Die();
        }
    }
}
