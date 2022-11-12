using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Food : MonoBehaviour
{
    [SerializeField] protected Tank _tank;
    [SerializeField] protected ColorController _colorController;
    [SerializeField] protected float _changingSpeed;

    public Color DefaultColor;

    public bool IsFilled;

    private Renderer _renderer;

    public event UnityAction<bool> Approached;

    public Renderer Renderer => _renderer;

    public bool IsApproached { get; private set; }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        DefaultColor = new Color32(217, 203, 203, 255);
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
        if (_colorController.TryGetColor(color) && CompareColor(color) && _tank.IsFilled )
        {
            this._renderer.material.DOColor(color, _changingSpeed);
            _tank.ChangeScale();
        }
    }

    public void Init(Tank tank, ColorController colorController)
    {
        _tank = tank;
        _colorController = colorController;
    }

    private bool CompareColor(Color color)
    {
        bool isPaited = false;
        if (this._renderer.material.color != color)
            isPaited = true;
        return isPaited;
    }
}
