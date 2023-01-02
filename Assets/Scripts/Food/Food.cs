using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HungryHead _hungryHead;

    private bool _isCooked;
    private int _reward = 10;
    public float _moveSpeed = 3f;

    private FoodPiece[] _foodPieces;

    public event UnityAction<Food> CookedFood;
    Tween tween;
    public int Reward => _reward;

    private void Update()
    {
        GetPaintedFood();
        OnCooked();
        //Cooked();
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

    private void Cooked()
    {
        if (_isCooked == true)
        {
            CookedFood?.Invoke(this);
            tween = transform.DOMove(_hungryHead.transform.position, _moveSpeed).OnComplete(() => gameObject.SetActive(false)) ;
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
        transform.position = Vector3.MoveTowards(transform.position, _hungryHead.transform.position, _moveSpeed * Time.fixedDeltaTime);
        CookedFood?.Invoke(this);
        yield return null;
        Invoke("Devour", 3.5f);
    }


    private void Devour()
    {
        Destroy(gameObject);
    }
}
