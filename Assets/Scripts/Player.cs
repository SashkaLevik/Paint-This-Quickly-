using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public Color DefaultColor;    

    private Renderer _renderer;

    public Renderer Renderer => _renderer;
    

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        DefaultColor = _renderer.material.color;
    }
}
