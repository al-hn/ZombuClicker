using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    [SerializeField] public bool isOwned = false;
    [SerializeField] public int price = 0;

    public abstract void Apply();
}