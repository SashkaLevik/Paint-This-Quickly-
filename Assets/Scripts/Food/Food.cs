using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Food : MonoBehaviour
{
    [SerializeField] protected Tank _tank;
    [SerializeField] protected ColorController _colorController;
    [SerializeField] protected float _colorChangingSpeed;

    public bool IsFilled;

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

    public void OnTriggerExit(Collider other)
    {
        IsApproached = false;
        Approached?.Invoke(IsApproached);
    }

    public void ChangeFoodColor(Color color)
    {
        if (_colorController.TryGetColor(color))
        {
            this._renderer.material.DOColor(color, _colorChangingSpeed);
            _tank.ChangeScale(_tank._capacity);
        }
    }

    public void Init(Tank tank, ColorController colorController)
    {
        _tank = tank;
        _colorController = colorController;
    }
}
