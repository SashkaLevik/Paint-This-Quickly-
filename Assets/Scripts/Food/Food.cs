using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HungryHead _hungryHead;

    private float _flySpeed = 3f;
    private int _reward = 5;
    private bool _isCoocked;   

    public FoodPiece[] _foodPieces;

    public int Reward => _reward;

    public event UnityAction<Food> CookedFood;

    private void Start()
    {
        _foodPieces = this.GetComponentsInChildren<FoodPiece>();
    }

    private void OnEnable()
    {
        CookedFood += OnCooked;
    }

    private void OnDisable()
    {
        CookedFood -= OnCooked;
    }

    private void Update()
    {
        GetPaintedFood();
    }
   
    public void Init(Player player, HungryHead hungryHead)
    {
        _player = player;
        _hungryHead = hungryHead;
    }

    private void GetPaintedFood()
    {
        foreach (var piece in _foodPieces)
        {
            if (piece.IsPainted == false)
            {
                _isCoocked = false;
                break;                
            }
            else
            {
                _isCoocked = true;
            }
        }
        if (_isCoocked == true)
        {
            CookedFood?.Invoke(this);
        }
    }       

    private void OnCooked(Food food)
    {
        StartCoroutine(FlyToHead());
    }

    private IEnumerator FlyToHead()
    {
        yield return new WaitForSeconds(1);
        transform.position = Vector3.MoveTowards(transform.position, _hungryHead.transform.position, _flySpeed * Time.fixedDeltaTime);        
        _hungryHead.BeginEat();
        Destroy(gameObject, 1f);
    }
}
