using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private float _moveSpeed = 5f;

    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveLogic();
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
}
