using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Red : Platform
{
    private Color _red;

    private void OnEnable()
    {
        Approached += OnColorChange;
    }

    private void OnDisable()
    {
        Approached -= OnColorChange;
    }

    private void Update()
    {
        _red = _colorController.colors[0];
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            _tankView.ChangeTankColor(_red);
            
        }        
    }
}
