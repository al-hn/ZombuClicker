using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Weapon : MonoBehaviour
{
    Zombie zombie;
    [SerializeField] public int damage = 5;

    void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
    }

    public async void Attack()
    {
        zombie.health = zombie.health - damage;
        Debug.Log("ZOMBU HEALTH: " + zombie.health);

        if (zombie.health <= 0)
        {
            zombie.Die();
            await Task.Delay((int)(zombie.RespawnCooldown * 1000));
            zombie.Spawn();
        }
    }
}
