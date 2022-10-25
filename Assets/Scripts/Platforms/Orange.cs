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
        _orange = Color.magenta;
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            StartCoroutine(ColorChange(_orange));
        }
        else
            StopCoroutine(ColorChange(_orange));
    }
}
