using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeFood : Food
{
    private Color _orange;

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
        _orange = _colorController.colors[1];
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeFoodColor(_orange);
        }
    }
}