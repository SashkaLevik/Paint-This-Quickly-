using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    [SerializeField] protected Player _player;
    [SerializeField] protected float _colorChangingSpeed_;

    public event UnityAction<bool> Approached;

    public bool IsApproached { get; private set; }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
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
        if (_player.IsFilled == false)
        {
            _player.Renderer.material.DOColor(color, _colorChangingSpeed_);
            yield return null;
        }
        _player.IsFilled = true;
    }
}
