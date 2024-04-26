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
    [SerializeField] private TextMeshProUGUI Night;
    [SerializeField] private TextMeshProUGUI Day;
    [SerializeField] private TextMeshProUGUI judgment_night;
    [SerializeField] private float ColdownDays = 60f;
    [SerializeField] private float ChangeJudgment_night = 1;
    
    public void Start(){
        InvokeRepeating("DayAndNight" , 60f , ColdownDays );
    }

    private void DayAndNight(){
        if(Day.gameObject.active){
            Night.gameObject.SetActive(true);
            Day.gameObject.SetActive(false);
            judgment_night.gameObject.SetActive(false);}
        else {
          Night.gameObject.SetActive(false);
            Day.gameObject.SetActive(true);
            judgment_night.gameObject.SetActive(false);
            judgment_nightd();
        }
    }

    public void judgment_nightd(){
        float n = Random.Range(0,5);
        if(ChangeJudgment_night == n){
            judgment_night.gameObject.SetActive(true);
            Night.gameObject.SetActive(false);
            Day.gameObject.SetActive(false);
        }
        else{
            
        }
    }
}
