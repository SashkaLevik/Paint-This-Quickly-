using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] protected float _colorChangingSpeed;
    [SerializeField] private ColorController _colorController;

    public Color DefaultColor;
    public Color CurrentColor;
    private Renderer _renderer;
    private Vector3 _filledTank;
    private Vector3 _emptyTank;

    public bool IsFilled;

    public Renderer Renderer => _renderer;    

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        DefaultColor = new Color32(255, 222, 173, 255);
        _filledTank = new Vector3(0.4f, 0.4f, 0.4f);
        _emptyTank = new Vector3(0.4f, 0.02f, 0.4f);
    }

    private void Update()
    {
        CurrentColor = _renderer.material.color;
    }

    public void FillTank()
    {
        transform.DOScale(_filledTank, _colorChangingSpeed);
    }

    public void DrainTank()
    {
        transform.DOScale(_emptyTank, _colorChangingSpeed);
    }
}
