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
    [SerializeField] private FoodSpawner _spawner;

    private Tween _tweenSlider;

    public event UnityAction Starved;

    private void Start()
    {
        ChangeHunger();
    }
    
    private void OnEnable()
    {
        _spawner.LevelCompleted += ResetSlider;
    }

    private void OnDisable()
    {
        _spawner.LevelCompleted -= ResetSlider;
    }

    private void ChangeHunger()
    {
        _tweenSlider = _slider.DOValue(_slider.maxValue, _hungerSpeed).SetEase(Ease.Linear).OnComplete(() => Starved?.Invoke());
    }

    public void ResetSlider()
    {
        Debug.Log("Reset");
        _tweenSlider.Rewind();
        ChangeHunger();
        _slider.value = _slider.minValue;
    }    
}
