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
    [SerializeField] private UpgradeScreen _upgradeScreen;
    [SerializeField] private GameObject[] _tamplate;
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
    
    private FoodPiece[] _foodPieces;

    private void Start()
    {
        SpawnFood(_tamplate);
    }      
    
    private void SpawnFood(GameObject[] tamplate)
    {
        for (int i = 0; i < _tamplate.Length; i++)
        {
            int randomPos = Random.Range(0, _spawnPoints.Count);
            Food food = Instantiate(tamplate[i], _spawnPoints[randomPos].transform.position, tamplate[i].transform.rotation).GetComponent<Food>();
            food.Init(_player, _hungryHead);
            food.CookedFood += OnFoodCooked;
            _spawnPoints.RemoveAt(randomPos);
            _foodPieces = food.GetComponentsInChildren<FoodPiece>();            

            foreach (var foodPiece in _foodPieces)
            {
                foodPiece.Init(_tank, _colorController, _view);
            }
        }
    }

    private void OnFoodCooked(Food food)
    {
        food.CookedFood -= OnFoodCooked;
        _upgradeScreen.AddMoney(food.Reward);
    }
}
