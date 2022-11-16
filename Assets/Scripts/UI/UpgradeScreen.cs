using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private Button _levelUpButton;
    [SerializeField] private TankView _tank;
    
    private Vector3 _levelUpValue;

    public event UnityAction LevelUp;

    private void Start()
    {
        _levelUpValue = new Vector3(0.0f, 0.1f, 0.0f);
    }

    private void OnEnable()
    {
        _levelUpButton.onClick.AddListener(OnLevelUpButton);
    }

    private void OnDisable()
    {
        _levelUpButton.onClick.RemoveListener(OnLevelUpButton);
    }

    private void OnLevelUpButton()
    {
        _tank._capacity += _levelUpValue;
        LevelUp?.Invoke();
    }    
}
