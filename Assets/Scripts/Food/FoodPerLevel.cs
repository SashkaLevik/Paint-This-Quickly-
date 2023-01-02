using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPerLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] _firstLevelTamplate;
    [SerializeField] private GameObject[] _secondLevelTamplate;
    [SerializeField] private GameObject[] _thirdLevelTamplate;
    [SerializeField] private GameObject[] _currentLevel;
    [SerializeField] private NextLevelScreen _nextLevelScreen;

    public List<GameObject[]> _levels = new List<GameObject[]>();

    public int _levelNumber = 0;
    public GameObject[] CurrentLevel => _currentLevel;    

    private void Start()
    {
        _levels.Add(_firstLevelTamplate);
        _levels.Add(_secondLevelTamplate);
        _levels.Add(_thirdLevelTamplate);
    }

    private void Update()
    {
        GetLevel();
    }

    private void OnEnable()
    {
        _nextLevelScreen.LevelChanged += NextLevel;
    }

    private void OnDisable()
    {
        _nextLevelScreen.LevelChanged -= NextLevel;
    }


    public void GetLevel()
    {
        _currentLevel = _levels[GetNextLevel()];
    }

    private void NextLevel()
    {
        if (_levelNumber < _levels.Count)
        {
            _levelNumber += 1;
        }
    }

    private int GetNextLevel()
    {
        return _levelNumber;
    }
}
