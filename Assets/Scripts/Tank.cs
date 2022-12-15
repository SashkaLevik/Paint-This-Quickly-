using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Color _currentColor;
    [SerializeField]private Color _defaultColor;
    [SerializeField] private UpgradeScreen _upgradeScreen;

    private float _fullTank = 0.1f;
    private float _emtyTank = 0.1f;
    private float _scaleChangeValue = 0.1f;
    private float _levelUpValue = 0.1f;

    public Renderer _renderer;

    public float EmtyTank => _emtyTank;
    public float FullTank => _fullTank;
    public float ScaleChangeValue => _scaleChangeValue;
    
    public Color CurrentColor => _currentColor;
    public Color DefaultColor => _defaultColor;    

    private void OnEnable()
    {
        _upgradeScreen.LevelUp += OnLevelUp;
    }

    private void OnDisable()
    {
        _upgradeScreen.LevelUp -= OnLevelUp;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();        
    }

    private void Update()
    {
        _currentColor = _renderer.material.color;
    }

    private void OnLevelUp()
    {
        _fullTank += _levelUpValue;
    }
}
