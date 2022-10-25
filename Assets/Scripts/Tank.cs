using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Color DefaultColor;

    private Renderer _renderer;

    public bool IsFilled;

    public Renderer Renderer => _renderer;


    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
}
