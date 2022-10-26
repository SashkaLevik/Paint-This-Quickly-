using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : Platform
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

    private void Start()
    {
        _green = new Color32(0, 128, 0, 255);
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeColor(_green);
        }
    }
}
