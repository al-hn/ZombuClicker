using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ScriptsMusic : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI on;
    [SerializeField] private TextMeshProUGUI off;

    public void SetVoLume()
    {
        audioSource.volume = slider.value;
    }

    public void ToggleText()
    {
        if (off.gameObject.active)
        {
            off.gameObject.SetActive(false);
            on.gameObject.SetActive(true);
            audioSource.mute = true;
        }
        else
        {
            off.gameObject.SetActive(true);
            on.gameObject.SetActive(false);
            audioSource.mute = false;
        }
    }
}