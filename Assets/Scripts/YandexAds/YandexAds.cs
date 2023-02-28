#pragma warning disable

using System;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class YandexAds : MonoBehaviour
{
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private Button _rewardButton;
    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private LevelScreen _levelScreen;
    [SerializeField] private YandexInitialization _yandexInitialization;

    public bool IsShows { get; private set; }

    public event UnityAction Shows;
    public event UnityAction RewardedAddShowed;

    private void Start()
    {
        _rewardButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _yandexInitialization.Completed += ApearRewardButton;
        _foodSpawner.LevelCompleted += ShowInterstitial;
        _levelScreen.NextLevelStarted += ApearRewardButton;
        _rewardButton.onClick.AddListener(ShowRewardAd);
    }

    private void OnDisable()
    {
        _yandexInitialization.Completed -= ApearRewardButton;
        _foodSpawner.LevelCompleted -= ShowInterstitial;
        _levelScreen.NextLevelStarted -= ApearRewardButton;
        _rewardButton.onClick.RemoveListener(ShowRewardAd);
    }

    public void ApearRewardButton()
    {
        _rewardButton.gameObject.SetActive(true);
    }

    private void ShowInterstitial()
    {
        InterstitialAd.Show();
    }

    private void ShowRewardAd()
    {
        VideoAd.Show(OnAdOpen, OnAdClose);
        RewardedAddShowed?.Invoke();
        _rewardButton.gameObject.SetActive(false);
    }
    
    private void OnAdOpen()
    {
        IsShows = true;
        Time.timeScale = 0;
        AudioListener.volume = 0;
    }

    private void OnAdClose()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
}
