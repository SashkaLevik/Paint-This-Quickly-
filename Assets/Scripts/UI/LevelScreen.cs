using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class LevelScreen : MonoBehaviour
{
    [SerializeField] private Button _backToMenu;
    [SerializeField] private Button _firstLevel;
    [SerializeField] private Button _secondLevel;
    [SerializeField] private Button _thirdLevel;
    [SerializeField] private Button _foursLevel;
    [SerializeField] private Button _fifthLevel;    
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private List<Image> _pathimages;
    [SerializeField] private Food[] _firstTamplate;
    [SerializeField] private Food[] _secondTamplate;
    [SerializeField] private Food[] _thirdTamplate;
    [SerializeField] private Food[] _foursTamplate;
    [SerializeField] private Food[] _fifthTamplate;
    [SerializeField] private AudioSource _tapSound;
    [SerializeField] private Score _score;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Player _player;

    public event UnityAction ReturnToMenu;
    public event UnityAction NextLevelStarted;

    private void Start()
    {
        _buttons.AddRange(new List<Button> {_firstLevel, _secondLevel, _thirdLevel, _foursLevel, _fifthLevel });
        ResetButtons();
        OpenCompleteLevels();
        _levelPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _menuScreen.NewGameStarted += StartNewGame;
        _menuScreen.Continued += ChooseLevel;
        _foodSpawner.LevelCompleted += NextLevel;
        _backToMenu.onClick.AddListener(Return);
        _firstLevel.onClick.AddListener(() => OnLevelButton(_firstTamplate));
        _secondLevel.onClick.AddListener(() => OnLevelButton(_secondTamplate));
        _thirdLevel.onClick.AddListener(() => OnLevelButton(_thirdTamplate));
        _foursLevel.onClick.AddListener(() => OnLevelButton(_foursTamplate));
        _fifthLevel.onClick.AddListener(() => OnLevelButton(_fifthTamplate));
    }

    private void OnDisable()
    {
        _menuScreen.NewGameStarted -= StartNewGame;
        _menuScreen.Continued -= ChooseLevel;
        _foodSpawner.LevelCompleted -= NextLevel;
        _backToMenu.onClick.RemoveListener(Return);
        _firstLevel.onClick.RemoveListener(() => OnLevelButton(_firstTamplate));
        _secondLevel.onClick.RemoveListener(() => OnLevelButton(_secondTamplate));
        _thirdLevel.onClick.RemoveListener(() => OnLevelButton(_thirdTamplate));
        _foursLevel.onClick.RemoveListener(() => OnLevelButton(_foursTamplate));
        _fifthLevel.onClick.RemoveListener(() => OnLevelButton(_fifthTamplate));
    }

    private void StartNewGame()
    {
        ResetButtons();
        ChooseLevel();
    }

    private void ChooseLevel()
    {
        _levelPanel.SetActive(true);
        Time.timeScale = 0;
    }    

    private void ResetButtons()
    {
        _firstLevel.interactable = true;
        _secondLevel.interactable = false;
        _thirdLevel.interactable = false;
        _foursLevel.interactable = false;
        _fifthLevel.interactable = false;        
    }

    private void OpenCompleteLevels()
    {        
        for (int i = 0; i < _foodSpawner.CurrentLevel; i++)
        {
            foreach (var button in _buttons)
            {
                if (button.interactable == false)
                {
                    button.interactable = true;
                    break;
                }
            }            
        }
    }

    private void Return()
    {
        _levelPanel.SetActive(false);
        ReturnToMenu?.Invoke();
    }

    private void OnLevelButton(Food[] tamplate)
    {
        _player.SetPosition();
        _scoreText.text = _score.TotalScore.ToString();
        _levelPanel.SetActive(false);
        _tapSound.Play();
        _foodSpawner.SpawnFood(tamplate);
        NextLevelStarted?.Invoke();
        Time.timeScale = 1;
    }    

    private void NextLevel()
    {
        _levelPanel.SetActive(true);
        Time.timeScale = 0;

        foreach (var button in _buttons)
        {
            if (button.interactable == false)
            {
                button.interactable = true;
                break;
            }            
        }
    }
}
