using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Tube : MonoBehaviour
{
    [SerializeField] protected Tank _tank;
    [SerializeField] protected View _view;
    [SerializeField] protected Color _tubeColor;
    [SerializeField] protected float _colorChangingSpeed;
    [SerializeField] private UpgradeScreen _upgradeScreen;

    public event UnityAction Approached;

    public Color Color => _tubeColor;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Tank>(out _tank))
        {
            Approached?.Invoke();
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
