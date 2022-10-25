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
        _green = Color.green;
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            StartCoroutine(ColorChange(_green));
        }
        else
            StopCoroutine(ColorChange(_green));
    }
}
