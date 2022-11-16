using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenFood : Food
{
    private Color _green;

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
        _green = _colorController.colors[3];
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeFoodColor(_green);
        }
    }
}