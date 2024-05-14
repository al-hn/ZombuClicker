using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverItem8 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverPanel.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverPanel.gameObject.SetActive(false);
    }
}
