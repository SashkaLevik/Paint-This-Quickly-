using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private float _score;
    [SerializeField] private int _currentScore;
    [SerializeField] private Hunger _hunger;

    public int CurrentScore => _currentScore;

    private void Start()
    {
        _score = _hunger.HungerSpeed;
    }

    private void Update()
    {
        _score -= Time.deltaTime;
    }

    private void OnEnable()
    {
        _foodSpawner.LevelCompleted += RoundScore;
    }

    private void OnDisable()
    {
        _foodSpawner.LevelCompleted -= RoundScore;
    }

    public void Init(float score)
    {
        _score = score;
    }

    private void RoundScore()
    {
        _currentScore = Mathf.RoundToInt(_score);
    }
}
