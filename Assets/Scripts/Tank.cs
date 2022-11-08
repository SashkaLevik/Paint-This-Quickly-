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
    private Renderer _renderer;
    private Vector3 _firstLevel;
    private Vector3 _emptyTank;
    private Vector3 _secondLevel;

    public int _tankCapacity = 1;
    public bool IsFilled;

    public Renderer Renderer => _renderer;    

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        DefaultColor = new Color32(255, 222, 173, 255);
        _firstLevel = new Vector3(0.4f, 0.2f, 0.4f);
        _emptyTank = new Vector3(0.2f, 0.02f, 0.2f);
        _secondLevel = new Vector3(0.4f, 0.4f, 0.4f);
    }

    private void Update()
    {
        CurrentColor = _renderer.material.color;
    }

    public void FillTank()
    {
        transform.DOScale(_firstLevel, _colorChangingSpeed);
    }

    public void DrainTank()
    {
        transform.DOScale(_emptyTank, _colorChangingSpeed);
    }

}
