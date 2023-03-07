using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _leaderboard;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private LevelScreen _levelScreen;
    [SerializeField] private GameOverScreen _gameOver;
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private AudioSource _tapSound;
    [SerializeField] private AudioSource _returnSound;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private Player _player;

    public event UnityAction Continued;
    public event UnityAction NewGameStarted;
    public event UnityAction LeaderboardOpened;

    private void Awake()
    {
        _saveSystem.Load();
    }

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _leaderboard.onClick.AddListener(OpenLeaderboard);
        _newGameButton.onClick.AddListener(PlayGame);
        _continueButton.onClick.AddListener(Continue);
        _exitButton.onClick.AddListener(ExitGame);
        _levelScreen.ReturnToMenu += OpenMenu;
        _gameOver.Died += OpenMenu;
        _gameScreen.Returned += OpenMenu;

    }

    private void OnDisable()
    {
        _leaderboard.onClick.RemoveListener(OpenLeaderboard);
        _newGameButton.onClick.RemoveListener(PlayGame);
        _continueButton.onClick.RemoveListener(Continue);
        _exitButton.onClick.RemoveListener(ExitGame);
        _levelScreen.ReturnToMenu -= OpenMenu;
        _gameOver.Died -= OpenMenu;
        _gameScreen.Returned -= OpenMenu;
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
        NewGameStarted?.Invoke();
    }

    private void Continue()
    {
        _menuPanel.SetActive(false);
        _tapSound.Play();
        Continued?.Invoke();
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
