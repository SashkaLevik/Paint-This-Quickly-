using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HungryHead : MonoBehaviour
{
    private Animator _animator;

    public const string Eat = "Eat";

    private void Start()
    {
        _animator = GetComponent<Animator>();        
    }       

    public void BeginEat()
    {
        _animator.SetTrigger(Eat);
    }
}
