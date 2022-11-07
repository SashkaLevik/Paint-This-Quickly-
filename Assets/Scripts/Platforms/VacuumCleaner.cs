using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleaner : Platform
{
    private Color _defaultColor;

    private void OnEnable()
    {
        Approached += OnColorChange;
    }

    private void OnDisable()
    {
        Approached -= OnColorChange;
    }

    private void Start()
    {
        _defaultColor = _tank.DefaultColor;
    }

    public override void ChangeTankColor(Color color)
    {
        if (_tank.IsFilled == true)
        {
            _tank.Renderer.material.DOColor(color, _colorChangingSpeed);
            _tank.DrainTank();
        }
        _tank.IsFilled = false;
    }


    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeTankColor(_defaultColor);
        }        
    }
}
