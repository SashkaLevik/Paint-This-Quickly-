using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : Platform
{
    private Color _yellow;

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
        _yellow = _colorController.colors[2];
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            _tankView.ChangeTankColor(_yellow);
        }
    }
}
