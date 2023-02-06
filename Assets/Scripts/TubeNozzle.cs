using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TubeNozzle : MonoBehaviour
{
    [SerializeField] private GunNozzle _gun;

    public event UnityAction GunApproached;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<GunNozzle>(out _gun))
        {
            GunApproached?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
