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

    public Color DefaultColor;
    public Color CurrentColor;

    private Renderer _renderer;

    private void Start()
    {
        DefaultColor = new Color32(255, 222, 173, 255);
        _renderer = GetComponent<Renderer>();
        _tank = GetComponent<Tank>();
    }

    private void Update()
    {
        CurrentColor = _renderer.material.color;
    }

    public virtual void ChangeTankColor(Color color)
    {
        if (_tank._isFilled == false)
        {
            _renderer.material.DOColor(color, _changingSpeed);
        }
    }
}
