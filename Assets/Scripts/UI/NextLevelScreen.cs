using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NextLevelScreen : MonoBehaviour
{
    [SerializeField] private Button _nextLevel;

    public event UnityAction LevelChanged; 

    private void OnEnable()
    {
        _nextLevel.onClick.AddListener(OnLevelChanged);
    }

    private void OnDisable()
    {
        _nextLevel.onClick.RemoveListener(OnLevelChanged);
    }

    private void OnLevelChanged()
    {
        LevelChanged?.Invoke();
    }
}
