using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BraunFood : Food
{
    private Color _braun;

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
        _braun = _colorController.colors[7];
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeFoodColor(_braun);
        }
    }
}
