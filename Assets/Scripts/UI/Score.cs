using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private float _score;
    [SerializeField] private int _currentScore;
    [SerializeField] private Hunger _hunger;
    [SerializeField] private int _totalScore;

    public int TotalScore => _totalScore;
    public int CurrentScore => _currentScore;

    private void Start()
    {
        SetScoreTimer();
    }

    private void Update()
    {
        _score -= Time.deltaTime;
    }

    private void OnEnable()
    {
        _foodSpawner.LevelCompleted += RoundScore;
        _foodSpawner.LevelCompleted += SetScoreTimer;
    }

    private void OnDisable()
    {
        _foodSpawner.LevelCompleted -= RoundScore;
        _foodSpawner.LevelCompleted -= SetScoreTimer;
    }

    public void Init(int score)
    {
        _totalScore = score;
    }

    private void RoundScore()
    {
        _currentScore = Mathf.RoundToInt(_score);
        _totalScore += _currentScore;
    }

    private void SetScoreTimer()
    {
        _score = _hunger.HungerSpeed;
        _currentScore = 0;
    }
}
