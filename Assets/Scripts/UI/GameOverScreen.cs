using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Hunger _hunger;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private Button _toMenu;    

    public event UnityAction Died;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
    }

    private void OnEnable()
    {
        _toMenu.onClick.AddListener(Die);
        _hunger.Starved += StopPlaying;
    }

    private void OnDisable()
    {
        _toMenu.onClick.RemoveListener(Die);
        _hunger.Starved -= StopPlaying;
    }

    private void StopPlaying()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        ClearTable();
        Debug.Log("YouDie");
    }

    private void Die()
    {
        Died?.Invoke();
        _hunger.ResetSlider();
        _gameOverPanel.SetActive(false);
    }

    private void ClearTable()
    {
        Food[] foods = FindObjectsOfType<Food>();

        foreach (Food food in foods)
        {
            Destroy(food.gameObject);
        }
    }
}
