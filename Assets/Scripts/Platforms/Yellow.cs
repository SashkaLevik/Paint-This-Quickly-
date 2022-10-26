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

    private void Start()
    {
        _yellow = Color.yellow;
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            ChangeColor(_yellow);
        }
    }
}
