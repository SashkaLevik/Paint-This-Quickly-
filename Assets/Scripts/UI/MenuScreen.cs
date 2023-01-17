using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private LevelScreen _levelScreen;
    [SerializeField] private GameOverScreen _gameOver;
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private AudioSource _tapSound;
    [SerializeField] private AudioSource _returnSound;

    public event UnityAction GameStarted;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(PlayGame);
        _exitButton.onClick.AddListener(ExitGame);
        _levelScreen.ReturnToMenu += OpenMenu;
        _gameOver.Died += OpenMenu;
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(PlayGame);
        _exitButton.onClick.RemoveListener(ExitGame);
        _levelScreen.ReturnToMenu -= OpenMenu;
        _gameOver.Died -= OpenMenu;
    }

    private void PlayGame()
    {
        _menuPanel.SetActive(false);
        _tapSound.Play();
        GameStarted?.Invoke();
    }

    private void OpenMenu()
    {
        _menuPanel.SetActive(true);
        Time.timeScale = 0;
        _returnSound.Play();
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
