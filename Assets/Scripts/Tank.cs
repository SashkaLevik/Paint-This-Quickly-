using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tank : MonoBehaviour
{
    private float _maxCapacity = 1;
    private float _minCapacity = 0;
    private float _currentCapacity;

    public float MaxCapacity => _maxCapacity;
    public bool IsApproached { get; private set; }

    public event UnityAction Filled;

    public bool _isFilled = false;

    private void Start()
    {
        _currentCapacity = _minCapacity;
    }

    private void FillTank()
    {
        
    }
}
