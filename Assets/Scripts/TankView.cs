using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TankView : MonoBehaviour
{
    [SerializeField] protected float _changingSpeed;
    [SerializeField] private ColorController _colorController;
    [SerializeField] private UpgradeScreen _upgradeScreen;

    public Color DefaultColor;
    public Color CurrentColor;
    public Vector3 _capacity;
    private Renderer _renderer;
    private Vector3 _emptyTank;    
    private Vector3 _scaleChangeValue;
    private Vector3 _currentCapacity;

    public bool IsFilled;

    public Renderer Renderer => _renderer;    

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        DefaultColor = new Color32(255, 222, 173, 255);
        _emptyTank = new Vector3(0.4f, 0.1f, 0.4f);
        _capacity = new Vector3(0.4f, 0.2f, 0.4f);
        _scaleChangeValue = new Vector3(0.0f, 0.1f, 0.0f);
    }    

    private void Update()
    {
        CurrentColor = _renderer.material.color;
    }    

    public void FillTank(Vector3 tankLevel)
    {
        transform.DOScale(tankLevel, _changingSpeed);
        _currentCapacity = _capacity;
        IsFilled = true;
    }

    public void DrainTank()
    {
        transform.DOScale(_emptyTank, _changingSpeed);
    }

    public void ChangeScale()
    {
        if (_currentCapacity.y > _emptyTank.y)
        {
            Vector3 changeValue = _currentCapacity - _scaleChangeValue;
            transform.DOScale(changeValue, _changingSpeed);            
            _currentCapacity = changeValue;
        }
        else
        {
            this._renderer.material.color = DefaultColor;
            IsFilled = false;
        }
    }


}
