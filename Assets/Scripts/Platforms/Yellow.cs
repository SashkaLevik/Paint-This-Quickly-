using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Renderer _playerRenderer;

    private void Start()
    {
        _playerRenderer = _player.GetComponent<Renderer>();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
        {
            _playerRenderer.material.color = Color.yellow;
        }
    }
}
