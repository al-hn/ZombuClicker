using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseHPValue : MonoBehaviour
{
    public Zombie zombie;
    [SerializeField] public int BaseHealth = 100;
    public TextMeshProUGUI BSValue;

    // Start is called before the first frame update
    void Start()
    {
        BSValue = GameObject.Find("Value base HP").GetComponent<TextMeshProUGUI>();
        zombie = GameObject.Find("Zombu").GetComponent<Zombie>();
    }

    // Update is called once per frame
    void Update()
    {
        BSValue.text = $"{BaseHealth}"; 
    }
   
}
