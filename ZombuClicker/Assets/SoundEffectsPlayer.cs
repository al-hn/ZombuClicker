using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip buttonClick, coin, ding, error, jumpscaresound;

    public void ButtonClick()
    {
        src.clip = buttonClick;
        src.Play();
    }

    public void coinSound()
    {
        src.clip = coin;
        src.Play();
    }

    public void dingSound()
    {
        src.clip = ding;
        src.Play();
    }

    public void errorSound()
    {
        src.clip = error;
        src.Play();
    }

    public void jumpscare()
    {
        src.clip = jumpscaresound;
        src.Play();
    }
}
