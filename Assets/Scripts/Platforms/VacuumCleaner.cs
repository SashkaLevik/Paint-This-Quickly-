using UnityEngine;
using UnityEngine.Events;

public class VacuumCleaner : MonoBehaviour
{
    [SerializeField] protected Pistol _pistol;
    [SerializeField] protected Tank _tank;
    [SerializeField] protected TankView _view;
    [SerializeField] protected Color _defaultColor;    

    public event UnityAction Approached;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Tank>(out _tank))
        {
            Approached?.Invoke();
        }
    }

    private void OnEnable()
    {
        Approached += OnTankApproached;
    }

    private void OnDisable()
    {
        Approached -= OnTankApproached;
    }
    
    private  void OnTankApproached()
    {
        _view.DrainTank(_defaultColor, _tank.EmtyTank);
        _pistol.Drain(_defaultColor);
    }
}
