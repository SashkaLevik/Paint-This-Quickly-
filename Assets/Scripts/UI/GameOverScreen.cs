using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Hunger _hunger;
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
    }

    private void OnEnable()
    {
        _hunger.Starved += StopPlaying;
    }

    private void OnDisable()
    {
        _hunger.Starved += StopPlaying;
    }

    private void StopPlaying()
    {
        _gameOverPanel.SetActive(true);
        Debug.Log("YouDie");
    }
}
