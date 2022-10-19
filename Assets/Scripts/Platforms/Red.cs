using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Platform
{   
    private Color _targetColor;
    private float _changingSpeed = 0.05f;
    private int a;
    

    private void OnEnable()
    {
        Approached += OnStartPainting;
    }

    private void OnDisable()
    {
        Approached -= OnStartPainting;
    }

    private void Start()
    {
        _targetColor = _player.DefaultColor;
        _targetColor.g = 1f;
        _targetColor.b = 1f;        
    }
    
    private IEnumerator PaintingRed()
    {
        for (float i = 1f; i >= 0; i -= 0.05f)
        {
            _targetColor = _player.Renderer.material.color;
            _targetColor.g = i;
            _targetColor.b = i;
            _player.Renderer.material.color = _targetColor;
            yield return new WaitForSeconds(_changingSpeed);
        }
    }

    private void OnStartPainting()
    {
        StartCoroutine(PaintingRed());
    }
}
