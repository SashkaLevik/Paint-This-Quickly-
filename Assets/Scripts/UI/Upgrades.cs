using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Tank _tank;
    [SerializeField] private Button _tankLevelUp;
    [SerializeField] private Button _speedLevelUp;
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private TMP_Text _speedLevelText;
    [SerializeField] private TMP_Text _tankLevelText;
    [SerializeField] private GameObject _panel;
    [SerializeField] private int _money;

    private int _speedLevel;
    private int _tankLevel;
    private int _speedUpgradeCost = 30;
    private int _tankUpgradeCost = 60;
    private int _rewardForAd = 10;

    public int Money => _money;
    public int SpeedLevel => _speedLevel;
    public int TankLevel => _tankLevel;

    public event UnityAction SpeedLevelUp;
    public event UnityAction TankLevelUp;

    private void Start()
    {
        _panel.SetActive(false);
        _moneyCount.text = _money.ToString();        
    }

    private void OnEnable()
    {
        _tankLevelUp.onClick.AddListener(OnTankLevelUp);
        _speedLevelUp.onClick.AddListener(OnSpeedLevelUp);
    }

    private void OnDisable()
    {
        _tankLevelUp.onClick.RemoveListener(OnTankLevelUp);
        _speedLevelUp.onClick.RemoveListener(OnSpeedLevelUp);
    }    

    public void AddMoney(int money)
    {
        _money += money;
        _moneyCount.text = _money.ToString();
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void InitMoney(int money)
    {
        _money = money;
        _moneyCount.text = _money.ToString();
    }

    public void InitSpeed(int speedLevel)
    {
        _speedLevel = speedLevel;
        _speedLevelText.text = _speedLevel.ToString();
    }

    public void InitTank(int tankLevel)
    {
        _tankLevel = tankLevel;
        _tankLevelText.text = _tankLevel.ToString();
    }

    public void RewardPlayer()
    {
        _money += _rewardForAd;
        _moneyCount.text = _money.ToString();
    }

    private bool TryUpgrade(int price)
    {
        if (_money >= price)
        {
            _money -= price;
            _moneyCount.text = _money.ToString();
            return true;
        }
        return false;
    }

    private void OnSpeedLevelUp()
    {
        if (TryUpgrade(_speedUpgradeCost))
        {
            _speedLevel+=1;
            _speedLevelText.text = _speedLevel.ToString();
            SpeedLevelUp?.Invoke();
        }
    }

    private void OnTankLevelUp()
    {
        if (TryUpgrade(_tankUpgradeCost))
        {
            _tankLevel++;
            _tankLevelText.text = _tankLevel.ToString();
            TankLevelUp?.Invoke();
        }
    }    
}
