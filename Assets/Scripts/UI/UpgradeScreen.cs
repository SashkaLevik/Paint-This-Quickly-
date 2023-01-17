using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeScreen : MonoBehaviour
{

    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _upgradePanel;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
        {
            _upgrades.OpenPanel(_upgradePanel);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
        {
            _upgrades.ClosePanel(_upgradePanel);
        }
    }
    
}
