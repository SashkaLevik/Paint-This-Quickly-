using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private LevelScreen _levelScreen;
    [SerializeField] private GameOverScreen _gameOver;
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private AudioSource _tapSound;
    [SerializeField] private AudioSource _returnSound;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private Button LB;

    public event UnityAction GameStarted;
    public event UnityAction LeaderboardOpened;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        LB.onClick.AddListener(OpenLeaderboard);
        _newGameButton.onClick.AddListener(PlayGame);
        _continueButton.onClick.AddListener(Continue);
        _exitButton.onClick.AddListener(ExitGame);
        _levelScreen.ReturnToMenu += OpenMenu;
        _gameOver.Died += OpenMenu;
    }

    private void OnDisable()
    {
        LB.onClick.RemoveListener(OpenLeaderboard);
        _newGameButton.onClick.RemoveListener(PlayGame);
        _continueButton.onClick.RemoveListener(Continue);
        _exitButton.onClick.RemoveListener(ExitGame);
        _levelScreen.ReturnToMenu -= OpenMenu;
        _gameOver.Died -= OpenMenu;
    }

    private void OpenLeaderboard()
    {
        LeaderboardOpened?.Invoke();
    }

    private void PlayGame()
    {
        _menuPanel.SetActive(false);
        _tapSound.Play();
        PlayerPrefs.DeleteAll();
        GameStarted?.Invoke();
    }

    private void Continue()
    {
        _saveSystem.Load();
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
