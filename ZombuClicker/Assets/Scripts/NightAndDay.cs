using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.Burst.CompilerServices;
using UnityEngine.AI;

public class NightAndDay : MonoBehaviour
{
    public GameObject Night_B;
    public GameObject JN_B;
    [SerializeField] public TextMeshProUGUI Night;
    [SerializeField] public TextMeshProUGUI Day;
    [SerializeField] public TextMeshProUGUI judgment_night;
    [SerializeField] public float ColdownDays = 30f;
    [SerializeField] private float ChangeJudgment_night = 1;

    public void Start()
    {
        InvokeRepeating("DayAndNight", ColdownDays, ColdownDays);
    }

    private void DayAndNight()
    {
        if (Day.gameObject.active)
        {
            Night.gameObject.SetActive(true);
            Day.gameObject.SetActive(false);
            Night_B.gameObject.SetActive(true);
            JN_B.gameObject.SetActive(false);
            judgment_night.gameObject.SetActive(false);
        }
        else
        {
            Night.gameObject.SetActive(false);
            Day.gameObject.SetActive(true);
            Night_B.gameObject.SetActive(false);
            JN_B.gameObject.SetActive(false);
            judgment_night.gameObject.SetActive(false);
            judgment_nightd();
        }
    }

    public void judgment_nightd()
    {
        float n = Random.Range(0, 5);
        if (ChangeJudgment_night == n)
        {
            judgment_night.gameObject.SetActive(true);
            Night.gameObject.gameObject.SetActive(false);
            JN_B.gameObject.gameObject.SetActive(true);
            Day.gameObject.SetActive(false);
        }
        else
        {

        }
    }
}
