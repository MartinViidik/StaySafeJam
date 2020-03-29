using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    [SerializeField] private AudioSource rollOver;
    [SerializeField] private AudioSource select;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        rollOver.Play();
    }

    public void OnSelect(BaseEventData eventData)
    {
        @select.Play();
    }
}
