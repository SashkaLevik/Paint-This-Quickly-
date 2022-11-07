using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink : Platform
{
    private Color _pink;

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
        _pink = new Color32(255, 192, 203, 255);
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeTankColor(_pink);
        }
    }
}
