using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Food _food;
    [SerializeField] protected float _colorChangingSpeed;

    public Color DefaultColor;

    private Renderer _renderer;

    public bool IsFilled;

    public Renderer Renderer => _renderer;

    private void OnEnable()
    {
        _food.Approached += OnFoodColorChange;
    }

    private void OnDisable()
    {
        _food.Approached += OnFoodColorChange;
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
        _food.Renderer.material.DOColor(DefaultColor, _colorChangingSpeed);
    }
}
