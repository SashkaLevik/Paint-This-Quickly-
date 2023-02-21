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
    [SerializeField] private float _colorChangingSpeed;
    [SerializeField] protected GameObject _bubbles;

    public event UnityAction Approached;

    private Rigidbody _rigidbody;

    public Color TubeColor => _tubeColor;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _bubbles.SetActive(false);
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
        LoadPaint();
        _view.FillTank(_tubeColor, _tank.FullTank);
    }

    private void LoadPaint()
    {
        if (_view.IsFilled == false)
        {
            _bubbles.SetActive(true);
            _bubbles.transform.LookAt(_player.transform.position);
            Invoke(nameof(StopLoading), 2f);
        }        
    }
    
    private void StopLoading()
    {
        _bubbles.SetActive(false);
    }
}
