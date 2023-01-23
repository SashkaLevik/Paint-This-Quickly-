using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Tank _tank;
    [SerializeField] private View _view;
    [SerializeField] private HungryHead _hungryHead;
    [SerializeField] private ColorController _colorController;
    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private GameObject[] _tamplate;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    [SerializeField] private List<Food> _foods = new List<Food>();
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private SaveSystem _saveSystem;

    private int _currentLevel;

    private FoodPiece[] _foodPieces;
    public int CurrentLevel => _currentLevel;

    public event UnityAction LevelCompleted;

    public void SpawnFood(GameObject[] tamplate)
    {
        for (int i = 0; i < tamplate.Length; i++)
        {
            int randomPos = Random.Range(0, _spawnPoints.Count);
            Food food = Instantiate(tamplate[i], _spawnPoints[randomPos].transform.position, tamplate[i].transform.rotation).GetComponent<Food>();
            food.Init(_player, _hungryHead);
            _foods.Add(food);
            food.CookedFood += OnFoodCooked;
            _spawnPoints.RemoveAt(randomPos);
            _foodPieces = food.GetComponentsInChildren<FoodPiece>();            

            foreach (var foodPiece in _foodPieces)
            {
                foodPiece.Init(_tank, _colorController, _view);
            }
        }
    }

    public void Init(int currentLevel)
    {
        _currentLevel = currentLevel;
    }

    private void OnFoodCooked(Food food)
    {
        food.CookedFood -= OnFoodCooked;
        _upgrades.AddMoney(food.Reward);
        _foods.Remove(food);

        if (_foods.Count == 0)
        {
            _winSound.Play();
            Debug.Log("LevelComplete");
            Invoke("OnLevelComplete", 2f);
        }
    }
    
    private void OnLevelComplete()
    {
        _player.SetPosition();
        _currentLevel++;
        LevelCompleted?.Invoke();
        _saveSystem.Save();
        Debug.Log("LevelComplet");
    }
}
