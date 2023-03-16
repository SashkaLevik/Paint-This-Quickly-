using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private Button _sound;
    [SerializeField] private Button _toMenu;    
    [SerializeField] private Image _soundOn;
    [SerializeField] private Image _soundOff;
    [SerializeField] private Player _player;    
    [SerializeField] private SaveSystem _saveSystem;

    public event UnityAction Returned;

    private void Start()
    {
        _soundOff.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _toMenu.onClick.AddListener(ReturnToMenu);
        _sound.onClick.AddListener(OnSoundButton);        
    }

    private void OnDisable()
    {
        _toMenu.onClick.RemoveListener(ReturnToMenu);
        _sound.onClick.RemoveListener(OnSoundButton);
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

    private void ReturnToMenu()
    {
        Returned?.Invoke();
    }
}
