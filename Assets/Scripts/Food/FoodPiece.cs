using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class FoodPiece : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Pistol _pistol;
    [SerializeField] private Tank _tank;
    [SerializeField] private TankView _view;
    [SerializeField] private Color _foodColor;
    [SerializeField] private ColorController _colorController;
    [SerializeField] private float _changingSpeed;

    private bool _isPainted;
    private bool _isApproached;

    private Color _defaultColor;
    private Renderer _renderer;

    public event UnityAction Approached;

    public bool IsPainted =>_isPainted;
    public Renderer Renderer => _renderer;
    public Color FoodColor => _foodColor;
    public bool IsApproached => _isApproached;

    private void OnEnable()
    {
        Approached += OnColorChange;
    }

    private void OnDisable()
    {
        Approached -= OnColorChange;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = new Color32(217, 203, 203, 255);
    }    

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Tank>(out _tank))
        {
            _isApproached = true;
            Approached?.Invoke();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        _isApproached = false;
        Approached?.Invoke();
    }

    public void ChangeFoodColor(Color color)
    {
        if (_colorController.TryGetColor(color) && CompareColor(color))
        {
            this._renderer.material.DOColor(color, _changingSpeed);
            _isPainted = true;
            _player.PaintFood();
            _view.ChangeScale();
            _pistol.SetDefaultColor();
        }        
    }

    public void Init(Tank tank, ColorController colorController, TankView view, Player player, Pistol pistol)
    {
        _tank = tank;
        _view = view;
        _colorController = colorController;
        _player = player;
        _pistol = pistol;
    }    

    private void OnColorChange()
    {
        if (_isApproached == true)
        {
            ChangeFoodColor(_foodColor);
        }
    }

    private bool CompareColor(Color color)
    {
        bool isPainted = false;
        if (this._renderer.material.color != color)
            isPainted = true;
        return isPainted;
    } 
}
