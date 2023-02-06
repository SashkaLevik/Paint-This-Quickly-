# pragma warning disable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class SDK : MonoBehaviour
{
    [SerializeField] private FoodSpawner _foodSpawner;

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif
        yield return YandexGamesSdk.Initialize();
    }

    private void OnEnable()
    {
        _foodSpawner.LevelCompleted += ShowInterstitial;
    }

    private void OnDisable()
    {
        _foodSpawner.LevelCompleted -= ShowInterstitial;
    }

    private  void ShowInterstitial()
    {
        InterstitialAd.Show();
    }
}
