using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunNozzle : MonoBehaviour
{
    [SerializeField] private TubeNozzle _tubeNozzle;
    public Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _tubeNozzle.GunApproached += OnTubeApproached;
    }

    private void OnDisable()
    {
        _tubeNozzle.GunApproached -= OnTubeApproached;
    }

    private void OnTubeApproached()
    {
        transform.position = Vector3.MoveTowards(transform.position, _tubeNozzle.transform.position, Time.deltaTime);
        Debug.Log("Stuck");
    }
}
