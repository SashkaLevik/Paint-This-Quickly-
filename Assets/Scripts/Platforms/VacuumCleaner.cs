using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumCleaner : Platform
{
    private Color _defaultColor;

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
        _defaultColor = _player.DefaultColor;
    }

    public override IEnumerator ColorChange(Color color)
    {
        if (_player.IsFilled == true)
        {
            _player.Renderer.material.DOColor(color, _changingSpeed);
            yield return null;
        }
        _player.IsFilled = false;
    }

    private void OnColorChange(bool isApproached)
    {
        if (isApproached)
        {
            StartCoroutine(ColorChange(_defaultColor));
        }
        else
            StopCoroutine(ColorChange(_defaultColor));
    }
}
