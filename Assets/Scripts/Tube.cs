using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Tube : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] protected Tank _tank;
    [SerializeField] protected View _view;
    [SerializeField] protected Color _tubeColor;
    [SerializeField] protected float _colorChangingSpeed;

    public event UnityAction Approached;

    private Rigidbody _rigidbody;

    public Color Color => _tubeColor;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Tank>(out _tank))
        {
            Approached?.Invoke();
            //_player.LoadPaint();
        }
    }    

    private void OnEnable()
    {
        Approached += OnTankApproached;
    }

    private void OnDisable()
    {
        Approached -= OnTankApproached;
    }

    public virtual void OnTankApproached()
    {
        _view.FillTank(_tubeColor, _tank.FullTank);
    }
}
