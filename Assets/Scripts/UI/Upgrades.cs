using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _panel;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
        {
            _upgradeScreen.OpenPanel(_panel);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
        {
            _upgradeScreen.ClosePanel(_panel);
        }
    }
}
