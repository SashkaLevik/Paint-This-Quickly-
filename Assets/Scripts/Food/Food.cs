using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Food : MonoBehaviour
{
    [SerializeField] protected Tank _tank;

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
}
