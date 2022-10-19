using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour
{
    [SerializeField] protected Player _player;

    public event UnityAction Approached;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
        {
            Approached?.Invoke();
        }
    }
}
