using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : Platform
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

    private void Start()
    {
        _orange = new Color32(255, 165, 0, 255);
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeColor(_orange);
        }        
    }
}
