using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Blue : Platform
{
    private Color _blue;

    private void OnEnable()
    {
        Approached += OncolorChange;
    }

    private void OnDisable()
    {
        Approached -= OncolorChange;
    }

    private void Update()
    {
        _blue = _colorController.colors[4];
    }

    private void OncolorChange(bool isApproached)
    {
        if (isApproached)
        {
            _tankView.ChangeTankColor(_blue);
        }
    }
}
