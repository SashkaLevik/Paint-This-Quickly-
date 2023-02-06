using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private float _moveSpeed;
    
    private float _levelUpValue = 0.5f;

    private Animator _animator;
    private Rigidbody _rigidbody;

    public const string IsRun = "IsRun";
    public const string Load = "Load";

    public float MoveSpeed => _moveSpeed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();        
    }

    private void Update()
    {
        if (Input.GetKey("c"))
        {
            _animator.SetBool(IsRun, false);
            _animator.SetTrigger(Load);
        }
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

    public void Init(float speed)
    {
        _moveSpeed = speed;
    }

    public void LoadPaint()
    {
        _animator.SetBool(IsRun, false);
        _animator.SetTrigger(Load);
    }

    public void SetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void MoveLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(0.0f, 0.0f, moveVertical);
        Vector3 rotate = new Vector3(0.0f, moveHorizontal, 0.0f);

        if (moveVertical != 0 || moveHorizontal != 0)
        {
            _animator.SetBool(IsRun, true);
            transform.Translate(moveDirection * _moveSpeed * Time.fixedDeltaTime);
            transform.Rotate(rotate * _rotateSpeed * Time.fixedDeltaTime);
        }
        else
            _animator.SetBool(IsRun, false);
    }

    private void OnLevelUp()
    {
        _moveSpeed += _levelUpValue;               
    }           
}
