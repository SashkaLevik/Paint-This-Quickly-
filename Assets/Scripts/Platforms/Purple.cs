using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purple : Platform
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
            _tankView.ChangeTankColor(_purple);
        }
    }
}
