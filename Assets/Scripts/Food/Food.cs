using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    [SerializeField] private Player _player;

    private bool _isCooked;
    private int _reward = 10;

    private FoodPiece[] _foodPieces;

    public event UnityAction<Food> CookedFood;

    public int Reward => _reward;

    private void Update()
    {
        GetPaintedFood();
        Cooked();
    }        

    public void Init(Player player)
    {
        _player = player;
    }

    private void GetPaintedFood()
    {
        _foodPieces = this.GetComponentsInChildren<FoodPiece>();

        foreach (var piece in _foodPieces)
        {
            if (piece.IsPainted == false)
            {
                _isCooked = false;
                break;
            }
            else
            {
                _isCooked = true;
            }
        }       
    }

    private void Cooked()
    {
        if (_isCooked == true)
        {
            CookedFood?.Invoke(this);
            //Destroy(gameObject);
        }
    }
}
