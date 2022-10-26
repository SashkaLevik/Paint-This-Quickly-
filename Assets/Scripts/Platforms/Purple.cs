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

    private void Start()
    {
        _purple = new Color32(128, 0, 128, 255);
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeColor(_purple);
        }
    }
}
