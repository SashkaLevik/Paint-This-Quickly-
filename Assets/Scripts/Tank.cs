using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] protected float _colorChangingSpeed;
    [SerializeField] private ColorController _colorController;
    [SerializeField] private UpgradeScreen _upgradeScreen;

    public Color DefaultColor;
    public Color CurrentColor;
    public Vector3 _capacity;
    private Renderer _renderer;
    private Vector3 _emptyTank;    
    private Vector3 _value;

    public bool IsFilled;

    public Renderer Renderer => _renderer;    

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        DefaultColor = new Color32(255, 222, 173, 255);
        _emptyTank = new Vector3(0.4f, 0.1f, 0.4f);
        _capacity = new Vector3(0.4f, 0.1f, 0.4f);
        _value = new Vector3(0.0f, 0.1f, 0.0f);
    }    

    private void Update()
    {
        CurrentColor = _renderer.material.color;
    }    

    public void FillTank(Vector3 tankLevel)
    {
        transform.DOScale(tankLevel, _colorChangingSpeed);
    }

    public void DrainTank()
    {
        transform.DOScale(_emptyTank, _colorChangingSpeed);
    }

    public void ChangeScale(Vector3 capacity)
    {
        Vector3 changeValue = capacity - _value;
        transform.DOScale(changeValue, _colorChangingSpeed);
    }       
}
