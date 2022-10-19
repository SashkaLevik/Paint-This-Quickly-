using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Renderer _playerRenderer;
    private Color _targetColor;
    private float _changingSpeed = 0.5f;
    private Color _blue;

    private void Start()
    {
        _playerRenderer = _player.GetComponent<Renderer>();
        _targetColor = _playerRenderer.material.color;
        _targetColor.g = 1f;
        _targetColor.r = 1f;
        _playerRenderer.material.color = _targetColor;
        _blue = Color.blue;
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out _player))
        {
            StartPainting();
        }
    }

    private IEnumerator PaintingBlue()
    {
        for (float i = 1f; i >= 0; i -= 0.05f)
        {
            _targetColor = _playerRenderer.material.color;
            _targetColor.g = i;
            _targetColor.r = i;
            _playerRenderer.material.color = _targetColor;
            yield return new WaitForSeconds(_changingSpeed);
        }
    }

    private void StartPainting()
    {
        StartCoroutine(PaintingBlue());
    }
}
