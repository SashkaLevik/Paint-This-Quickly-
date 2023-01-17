using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelScreen : MonoBehaviour
{
    [SerializeField] private Button _backToMenu;
    [SerializeField] private Button _firstLevel;
    [SerializeField] private Button _secondLevel;
    [SerializeField] private Button _thirdLevel;
    [SerializeField] private Button _foursLevel;
    [SerializeField] private Button _fifthLevel;
    [SerializeField] private Image _firstPath;
    [SerializeField] private Image _secondPath;
    [SerializeField] private Image _thirdPath;
    [SerializeField] private Image _foursPath;
    [SerializeField] private GameObject _levelPanel;
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private List<Image> _pathimages;
    [SerializeField] private GameObject[] _firstTamplate;
    [SerializeField] private GameObject[] _secondTamplate;
    [SerializeField] private GameObject[] _thirdTamplate;
    [SerializeField] private GameObject[] _foursTamplate;
    [SerializeField] private GameObject[] _fifthTamplate;
    [SerializeField] private AudioSource _tapSound;

    public event UnityAction ReturnToMenu;

    private void Start()
    {
        _levelPanel.SetActive(false);
        _buttons.AddRange(new List<Button> { _secondLevel, _thirdLevel, _foursLevel, _fifthLevel });
        _pathimages.AddRange(new List<Image> { _firstPath, _secondPath, _thirdPath, _foursPath });
        _secondLevel.interactable = false;
        _thirdLevel.interactable = false;
        _foursLevel.interactable = false;
        _fifthLevel.interactable = false;
        _firstPath.gameObject.SetActive(false);
        _secondPath.gameObject.SetActive(false);
        _thirdPath.gameObject.SetActive(false);
        _foursPath.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _menuScreen.GameStarted += ChooseLevel;
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
        _menuScreen.GameStarted -= ChooseLevel;
        _foodSpawner.LevelCompleted -= NextLevel;
        _backToMenu.onClick.RemoveListener(Return);
        _firstLevel.onClick.RemoveListener(() => OnLevelButton(_firstTamplate));
        _secondLevel.onClick.RemoveListener(() => OnLevelButton(_secondTamplate));
        _thirdLevel.onClick.RemoveListener(() => OnLevelButton(_thirdTamplate));
        _foursLevel.onClick.RemoveListener(() => OnLevelButton(_foursTamplate));
        _fifthLevel.onClick.RemoveListener(() => OnLevelButton(_fifthTamplate));
    }

    private void ChooseLevel()
    {
        _levelPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void Return()
    {
        _levelPanel.SetActive(false);
        ReturnToMenu?.Invoke();
    }

    private void OnLevelButton(GameObject[] tamplate)
    {
        _levelPanel.SetActive(false);
        _tapSound.Play();
        _foodSpawner.SpawnFood(tamplate);
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

        foreach (var image in _pathimages)
        {
            if (image.gameObject.activeSelf == false)
            {
                image.gameObject.SetActive(true);
                break;
            }
        }
    }
}
