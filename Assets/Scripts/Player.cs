using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Upgrades _upgrades;    

    public float _moveSpeed = 4;
    private float _levelUpValue = 0.5f;

    private Animator _animator;
    private Rigidbody _rigidbody;

    public float MoveSpeed => _moveSpeed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveLogic();
    }    

    private void OnEnable()
    {
        _upgrades.SpeedLevelUp += OnLevelUp;
    }

    private void OnDisable()
    {
        _upgrades.SpeedLevelUp -= OnLevelUp;
    }

    private void MoveLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(0.0f, 0.0f, moveVertical);
        Vector3 rotate = new Vector3(0.0f, moveHorizontal, 0.0f);

        if (moveVertical != 0 || moveHorizontal != 0)
        {
            _animator.SetBool("IsRun", true);
            transform.Translate(moveDirection * _moveSpeed * Time.fixedDeltaTime);
            transform.Rotate(rotate * _rotateSpeed * Time.fixedDeltaTime);
        }
        else
            _animator.SetBool("IsRun", false);
    }

    private void OnLevelUp()
    {
        _moveSpeed += _levelUpValue;
    }    

    public void SetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();

        _moveSpeed = data.speedLevel;
    }
}
