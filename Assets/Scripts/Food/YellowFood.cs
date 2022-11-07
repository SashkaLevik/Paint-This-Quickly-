using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFood : Food
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
            ChangeFoodColor(_yellow);
        }
    }
}
