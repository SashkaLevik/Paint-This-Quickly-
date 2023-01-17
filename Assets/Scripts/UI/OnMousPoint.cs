using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnMousPoint : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioSource _onMousEnter;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _onMousEnter.Play();
    }
}
