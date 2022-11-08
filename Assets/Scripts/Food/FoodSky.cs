using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSky : Food
{
    private Color _sky;

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
        _sky = _colorController.colors[5];
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeFoodColor(_sky);
        }
    }
}
