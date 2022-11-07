using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleFood : Food
{
    private Color _purple;

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
        _purple = _colorController.colors[6];
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeFoodColor(_purple);
        }
    }
}
