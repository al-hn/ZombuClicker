using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseHPValue : MonoBehaviour
{
    [SerializeField] public int BaseHealth = 100;
    [SerializeField] public int Armor = 0;
    public TextMeshProUGUI BSValue;
    public TextMeshProUGUI ShieldText;

    void Start()
    {
        BSValue = GameObject.Find("Value base HP").GetComponent<TextMeshProUGUI>();
        ShieldText = GameObject.Find("armortext").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Armor = Mathf.Clamp(Armor, 0, 100);
        BaseHealth = Mathf.Clamp(BaseHealth, 0, 100);

        ShieldText.text = $"Shield {Armor}";
        BSValue.text = $"{BaseHealth}";
    }

}
