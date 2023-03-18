using UnityEngine;
using DG.Tweening;

public class Pistol : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;

    private float _changingSpeed = 3;
    private bool _isFilled = false;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Fill(Color color)
    {
        if(_isFilled == false)
        {
            _renderer.material.DOColor(color, _changingSpeed);
            _isFilled = true;
        }

    }

    public void Drain(Color color)
    {
        if (_isFilled == true)
        {
            _renderer.material.DOColor(color, _changingSpeed);
            _isFilled = false;
        }
    }

    public void SetDefaultColor()
    {
        _renderer.material.color = _defaultColor;
        _isFilled = false;
    }
}
