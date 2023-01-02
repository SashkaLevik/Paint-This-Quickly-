using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _tankLevelUp;
    [SerializeField] private Button _speedLevelUp;
    [SerializeField] private Tank _tank;
    [SerializeField] private TMP_Text _moneyCount;
    [SerializeField] private GameObject _panel;

    public int _money = 0;
    private int _speedUpgradeCost = 10;
    private int _tankUpgradeCost = 10;

    public event UnityAction SpeedLevelUp;
    public event UnityAction TankLevelUp;

    private void Start()
    {
        _panel.SetActive(false);
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

    private void OnLevelUpButton(int price)
    {
        if (_money >= price)
        {            
            _money -= price;
            _moneyCount.text = _money.ToString();
        }
    }

    private void OnTankLevelUp()
    {
        OnLevelUpButton(_tankUpgradeCost);
        TankLevelUp?.Invoke();
    }

    private void OnSpeedLevelUp()
    {
        OnLevelUpButton(_speedUpgradeCost);
        SpeedLevelUp?.Invoke();
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
}
