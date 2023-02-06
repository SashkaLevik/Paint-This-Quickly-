using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HungryHead _hungryHead;

    private float _flySpeed = 3f;
    private bool _isCooked;
    private int _reward = 10;

    private FoodPiece[] _foodPieces;
    public int Reward => _reward;

    public event UnityAction<Food> CookedFood;    

    private void Update()
    {
        GetPaintedFood();
        OnCooked();
    }
   
    public void Init(Player player, HungryHead hungryHead)
    {
        _player = player;
        _hungryHead = hungryHead;
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

    private void OnCooked()
    {
        if (_isCooked == true)
        {
            StartCoroutine(FlyToHead());
            return;
        }
        StopCoroutine(FlyToHead());
    }

    private IEnumerator FlyToHead()
    {
        yield return new WaitForSeconds(1);
        transform.position = Vector3.MoveTowards(transform.position, _hungryHead.transform.position, _flySpeed * Time.fixedDeltaTime);
        CookedFood?.Invoke(this);
        yield return new WaitForSeconds(1);
        _hungryHead.BeginEat();
        Devour();
    }

    private void Devour()
    {
        Destroy(gameObject);
    }
}
