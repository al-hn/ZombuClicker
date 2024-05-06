using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZombuHPValue : MonoBehaviour
{
  public TextMeshProUGUI hpValueText;
  public Zombie zombie;

  void Start()
  {
    hpValueText = GameObject.Find("Zombu HP value").GetComponent<TextMeshProUGUI>();
    zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
  }

  void Update()
  {
    zombie.currentHealth = Mathf.Clamp(zombie.currentHealth, 0, 100000);
    hpValueText.text = $"{zombie.currentHealth}";
  }
}
