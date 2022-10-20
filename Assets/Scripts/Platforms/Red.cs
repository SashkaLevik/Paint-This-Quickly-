using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Red : Platform
{
    private Color _red;

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
        _red = Color.red;        
    }    

    private void OnColorChange()
    {
        StartCoroutine(ColorChange(_red));
    }
}
