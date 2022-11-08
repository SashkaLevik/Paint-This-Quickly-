using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpgradeScreen : MonoBehaviour
{
    [SerializeField] private Button _levelUpButton;
    [SerializeField] private Tank _tank;

    public event UnityAction LevelUp;

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
        _tank._tankCapacity++;
    }
}
