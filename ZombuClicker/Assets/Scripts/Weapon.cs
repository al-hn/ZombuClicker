using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Unity.Mathematics;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Weapon : MonoBehaviour
{
    Zombie zombie;
    public GameObject popUPDamagePrefab;

    public TMP_Text popUpText;
    public GameObject ParentpopUpText;
    [SerializeField] public int damage = 5;
    FlashEffect fleff;
    [SerializeField] public int hitCount = 0;

    void Start()
    {
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
        fleff = GameObject.Find("Zombu").GetComponent<FlashEffect>();
        popUpText.text = damage.ToString();
    }

    public async void Attack()
    {
        hitCount = hitCount + 1;
        Debug.Log($"hitCount: {hitCount}");

        zombie.health = zombie.health - damage;
        Instantiate(popUPDamagePrefab, transform.position, quaternion.identity);

        Debug.Log("ZOMBU HEALTH: " + zombie.health);
        fleff.Flash();

        if (zombie.health <= 0)
        {
            zombie.Die();
            await Task.Delay((int)(zombie.RespawnCooldown * 1000));
            zombie.Spawn();
        }
    }

}
