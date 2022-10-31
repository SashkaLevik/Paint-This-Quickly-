using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] protected float _colorChangingSpeed;
    [SerializeField] private FoodContainer _foodContainer;
    [SerializeField] private ColorController _colorController;

    public Color DefaultColor;
    private Renderer _renderer;
    private Renderer _foodRenderer;

    public bool IsFilled;

    public Renderer Renderer => _renderer;

    private void OnEnable()
    {
        _foodContainer.food.Approached += OnFoodColorChange;
    }

    private void OnDisable()
    {
        _foodContainer.food.Approached += OnFoodColorChange;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        DefaultColor = _renderer.material.color;
    }

    private void OnFoodColorChange(bool isAproached)
    {
        foreach (var food in _foodContainer.foodContainer)
        {
            _foodRenderer = food.GetComponent<Renderer>();
            if (_colorController.TryGetColor())
            {
                _foodRenderer.material.DOColor(DefaultColor, _colorChangingSpeed);
            }


            //food.GetComponent<Renderer>().material.DOColor(DefaultColor, _colorChangingSpeed);
        }
    }
}
