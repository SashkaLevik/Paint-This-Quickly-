using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private Image _soundOn;
    [SerializeField] private Image _soundOff;
    [SerializeField] private Button _mute;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _leaderboard;
    [SerializeField] private Button _howToPlay;
    [SerializeField] private Button _howToPlayReturn;
    [SerializeField] private GameObject _howToPlayText;
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
        _continueButton.interactable = false;
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey(_saveSystem.Key))
        {
            _continueButton.interactable = true;
        }
    }

    private void Start()
    {
        Time.timeScale = 0;
        _howToPlayText.SetActive(false);
    }

    private void OnEnable()
    {
        _howToPlay.onClick.AddListener(OnDescription);
        _howToPlayReturn.onClick.AddListener(OnExitDescription);
        _mute.onClick.AddListener(OnSoundButton);
        _leaderboard.onClick.AddListener(OpenLeaderboard);
        _newGameButton.onClick.AddListener(PlayGame);
        _continueButton.onClick.AddListener(Continue);
        _levelScreen.ReturnToMenu += OpenMenu;
        _gameOver.Died += OpenMenu;
        _gameScreen.Returned += OpenMenu;
    }

    private void OnDisable()
    {
        _howToPlay.onClick.RemoveListener(OnDescription);
        _howToPlayReturn.onClick.RemoveListener(OnExitDescription);
        _mute.onClick.RemoveListener(OnSoundButton);
        _leaderboard.onClick.RemoveListener(OpenLeaderboard);
        _newGameButton.onClick.RemoveListener(PlayGame);
        _continueButton.onClick.RemoveListener(Continue);
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

    private void OnSoundButton()
    {
        if (_soundOff.gameObject.activeSelf == false)
        {
            _soundOff.gameObject.SetActive(true);
            _soundOn.gameObject.SetActive(false);
            AudioListener.volume = 0;
        }
        else
        {
            _soundOff.gameObject.SetActive(false);
            _soundOn.gameObject.SetActive(true);
            AudioListener.volume = 1;
        }
    }

    private void OnDescription()
    {
        _howToPlayText.SetActive(true);
    }

    private void OnExitDescription()
    {
        _howToPlayText.SetActive(false);
    }
}
