using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyan : Platform
{
    private Color _cyan;

    private void OnEnable()
    {
        Approached += OnColorChange;
    }

    private void OnDisable()
    {
        Approached -= OnColorChange;
    }

    private void Start()
    {
        _cyan = Color.cyan;
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            _tankView.ChangeTankColor(_cyan);
        }
    }
}
