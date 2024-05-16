using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerZombu : MonoBehaviour
{
    Zombie zombie;
    public GameObject Zombu;
    // Start is called before the first frame update
    void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
    }

    // Update is called once per frame
    public void SpawnZom(){
         if (zombie.nad.Day.gameObject.active)
        {
            zombie.gameObject.SetActive(true);
            zombie.fleff.img.material = zombie.fleff.originalMat;
            zombie.DefaultZombie();
            zombie.currentHealth = zombie.defaultZombuHealth;
            zombie.isAlive = true;
        }
        else if (zombie.nad.judgment_night.gameObject.active)
        {
            zombie.gameObject.SetActive(true);
            zombie.RollZombieInJudgment_night();
            zombie.isAlive = true;
        }
        else
        {
            zombie.gameObject.SetActive(true);
            zombie.RollZombie();
            zombie.isAlive = true;
        }
    }
      public void Die()
    {
        zombie.DropCoin();
        zombie.HpHealAfterKillZombie();
        zombie.isAlive = false;
        zombie.gameObject.SetActive(false);
        // Debug.Log("Zombie Is Killed");
    }
}
