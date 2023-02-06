using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private Button _sound;
    [SerializeField] private Image _gameStart;
    [SerializeField] private Image _gamePause;
    [SerializeField] private Image _soundOn;
    [SerializeField] private Image _soundOff;
    [SerializeField] private Player _player;    
    [SerializeField] private SaveSystem _saveSystem;

    private void Start()
    {
        _gameStart.gameObject.SetActive(false);
        _soundOff.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _pause.onClick.AddListener(OnPauseButton);
        _sound.onClick.AddListener(OnSoundButton);        
    }

    private void OnDisable()
    {
        _pause.onClick.RemoveListener(OnPauseButton);
        _sound.onClick.RemoveListener(OnSoundButton);
    }

    private void OnPauseButton()
    {
        if (_gameStart.gameObject.activeSelf == false)
        {
            _gameStart.gameObject.SetActive(true);
            _gamePause.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            _gameStart.gameObject.SetActive(false);
            _gamePause.gameObject.SetActive(true);
            Time.timeScale = 1;
        }
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
}
