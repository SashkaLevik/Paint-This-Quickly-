using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Food : MonoBehaviour
{
    [SerializeField] protected Tank _tank;
    [SerializeField] protected float _colorChangingSpeed;

    public bool IsFilled;

    public Color DefaultColor;

    private Renderer _renderer;

    public event UnityAction<bool> Approached;

    public Renderer Renderer => _renderer;

    public bool IsApproached { get; private set; }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Tank>(out _tank))
        {
            IsApproached = true;
            Approached?.Invoke(IsApproached);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IsApproached = false;
        Approached?.Invoke(IsApproached);
    }

    public void CookFood(Color color)
    {
        if (_tank.IsFilled == true)
        {
            this._renderer.material.DOColor(_tank.Renderer.material.color, _colorChangingSpeed);
        }
    }
}
