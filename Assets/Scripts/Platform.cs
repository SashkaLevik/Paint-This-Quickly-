using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    [SerializeField] protected Tank _tank;
    [SerializeField] protected float _colorChangingSpeed_;

    public event UnityAction<bool> Approached;

    public bool IsApproached { get; private set; }

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

    public virtual IEnumerator ColorChange(Color color)
    {
        if (_tank.IsFilled == false)
        {
            _tank.Renderer.material.DOColor(color, _colorChangingSpeed_);
            yield return null;
        }
        _tank.IsFilled = true;
    }
}
