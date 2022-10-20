using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Blue : Platform
{
    private Color _blue;

    private void OnEnable()
    {
        Approached += OncolorChange;
    }

    private void OnDisable()
    {
        Approached -= OncolorChange;
    }

    private void Start()
    {
        _blue = Color.blue;
    }

    private void OncolorChange(bool isApproached)
    {
        if (isApproached)
        {
            StartCoroutine(ColorChange(_blue));
        }
        else
            StopCoroutine(ColorChange(_blue));
    }
}
