using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Color _currentColor;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private MenuScreen _menuScreen;

    public float _fullTank = 0.1f;
    private float _emtyTank = 0.1f;
    private float _scaleChangeValue = 0.1f;
    private float _levelUpValue = 0.1f;

    public Renderer _renderer;

    public float EmtyTank => _emtyTank;
    public float FullTank => _fullTank;
    public float ScaleChangeValue => _scaleChangeValue;
    
    public Color CurrentColor => _currentColor;
    public Color DefaultColor => _defaultColor;    

    private void OnEnable()
    {
        _upgrades.TankLevelUp += OnLevelUp;
        _menuScreen.NewGameStarted += SetDefaultValues;
    }

    private void OnDisable()
    {
        _upgrades.TankLevelUp -= OnLevelUp;
        _menuScreen.NewGameStarted -= SetDefaultValues;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();        
    }

    private void Update()
    {
        _currentColor = _renderer.material.color;
    }

    public void Init(float capacity)
    {
        _fullTank = capacity;
    }

    private void OnLevelUp()
    {
        _fullTank += _levelUpValue;
    }

    private void SetDefaultValues()
    {
        _fullTank = 0.1f;
    }
}
