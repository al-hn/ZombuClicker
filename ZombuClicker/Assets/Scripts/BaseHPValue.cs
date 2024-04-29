using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseHPValue : MonoBehaviour
{

    [SerializeField] public int BaseHealth = 100;
    public TextMeshProUGUI BSValue;

    // Start is called before the first frame update
    void Start()
    {
        BSValue = GameObject.Find("Value base HP").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        BaseHealth = Mathf.Clamp(BaseHealth, 0, 100);
        BSValue.text = $"{BaseHealth}"; 
    }
   
}
