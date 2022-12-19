using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class Hunger : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _hungerSpeed;

    public event UnityAction Starved;

    private void Start()
    {
        ChangeHunger();
    }
   
    private void ChangeHunger()
    {
        _slider.DOValue(_slider.maxValue, _hungerSpeed).SetEase(Ease.Linear).OnComplete(() => Starved?.Invoke());
    }    
}
