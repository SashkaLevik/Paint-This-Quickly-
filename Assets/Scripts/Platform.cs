using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Platform : MonoBehaviour
{
    [SerializeField] protected Player _player;
    [SerializeField] private float _changingSpeed;

    public event UnityAction Approached;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
        {
            Approached?.Invoke();
        }
    }

    public IEnumerator ColorChange(Color color)
    {
        if (_player.IsFilled == false)
        {
            _player.Renderer.material.DOColor(color, _changingSpeed);
            yield return null;
        }
        _player.IsFilled = true;
    }
}
