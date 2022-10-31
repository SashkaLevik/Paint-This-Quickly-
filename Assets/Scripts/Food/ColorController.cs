using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Tank _tank;
    //public Color32 _color;
    public Color32 _purpleColor;

    //private Renderer _renderer;
    private void Start()
    {
        //_renderer = GetComponent<Renderer>();
        _purpleColor = new Color32(128, 0, 128, 255);
        //_renderer.material.color = _purpleColor;
    }

    public bool TryGetColor()
    {
        bool result = false;
        if (_tank.Renderer.material.color == _purpleColor)
            result = true;
        return result;
    }    
}
