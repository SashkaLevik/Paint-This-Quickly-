using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
        {
            _player.Renderer.material.color = Color.yellow;
        }
    }
}
