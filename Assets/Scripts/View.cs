using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class View : MonoBehaviour
{
    [SerializeField] private Tank _tank;
    [SerializeField] protected float _changingSpeed;
    [SerializeField] private ColorController _colorController;
    [SerializeField] private UpgradeScreen _upgradeScreen;
    
    private bool _isFilled = false;
    public float _currentCapacity;

    private Renderer _renderer;

    public bool IsFilled => _isFilled;    

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }        

    public void FillTank(Color color, float scale)
    {
        if (_isFilled == false)
        {
            _renderer.material.DOColor(color, _changingSpeed);
            transform.DOScaleY(scale, _changingSpeed);
            _currentCapacity = scale;
            _isFilled = true;
        }        
    }        

    public void DrainTank(Color color, float scale)
    {
        if (_isFilled == true)
        {
            _renderer.material.DOColor(color, _changingSpeed);
            transform.DOScaleY(scale, _changingSpeed);
            _currentCapacity = scale;
            _isFilled = false;
        }
    }

    public void ChangeScale()
    {
        if (_currentCapacity >= _tank.EmtyTank + 0.1f)
        {            
            float changeValue = _currentCapacity - _tank.ScaleChangeValue;
            transform.DOScaleY(changeValue, _changingSpeed);
            _currentCapacity = changeValue;
        }
        else
        {
            _renderer.material.color = _tank.DefaultColor;
            _isFilled = false;
        }
    }
}
