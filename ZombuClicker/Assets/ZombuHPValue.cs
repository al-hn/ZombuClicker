using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ZombuHPValue : MonoBehaviour
{
    public TextMeshProUGUI hpValueText;
    public Zombie zombie;
    // Start is called before the first frame update
    void Start()
    {
        hpValueText = GameObject.Find("Zombu HP value").GetComponent<TextMeshProUGUI>();
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
    }

    // Update is called once per frame
    void Update()
    {
      hpValueText.text = $"{zombie.health}";  
    }
}
