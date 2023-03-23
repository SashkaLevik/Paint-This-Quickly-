using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private GameObject _paintEffect;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private MenuScreen _menuScreen;
    
    private float _levelUpValue = 0.5f;
    private float _defaultSpeed = 4f;
    private float _paintDelay = 1f;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private CharacterController _controller;

    public const string IsRun = "IsRun";
    public const string Paint = "Paint";

    public float MoveSpeed => _moveSpeed;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _paintEffect.SetActive(false);
    }
    
    private void FixedUpdate()
    {
        MoveByKeyboard();
        MoveByJoystick();
    }

    private void OnEnable()
    {
        _upgrades.SpeedLevelUp += OnLevelUp;
        _menuScreen.NewGameStarted += SetDefaultValues;
    }

    private void OnDisable()
    {
        _upgrades.SpeedLevelUp -= OnLevelUp;
        _menuScreen.NewGameStarted -= SetDefaultValues;
    }

    public void Init(float speed)
    {
        _moveSpeed = speed;
    }    

    public void PaintFood()
    {
        _animator.SetTrigger(Paint);
        _paintEffect.SetActive(true);
        Invoke(nameof(StopPainting), _paintDelay);
    }

    public void SetPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void SetDefaultValues()
    {
        _moveSpeed = _defaultSpeed;
    }

    private void StopPainting()
    {
        _paintEffect.SetActive(false);
    }    
   
    private void MoveByKeyboard()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");      

        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        Vector3 rotation = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed * Time.fixedDeltaTime, 0);

        if (moveVertical != 0 || moveHorizontal != 0)
        {
            _animator.SetBool(IsRun, true);            
            transform.rotation = Quaternion.LookRotation(rotation);
            _controller.Move(moveDirection * _moveSpeed * Time.fixedDeltaTime);
        }
        else
            _animator.SetBool(IsRun, false);
    }

    private void MoveByJoystick()
    {
        Vector3 moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        Vector3 rotation = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed * Time.fixedDeltaTime, 0);

        if (_joystick.Horizontal != 0 || _joystick.Vertical !=0)
        {
            _animator.SetBool(IsRun, true);
            transform.rotation = Quaternion.LookRotation(rotation);
            _controller.Move(moveDirection * _moveSpeed * Time.fixedDeltaTime);            
        }
    }

    private void OnLevelUp()
    {
        _moveSpeed += _levelUpValue;               
    }           
}
