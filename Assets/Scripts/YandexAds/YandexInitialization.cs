#pragma warning disable

using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class YandexInitialization : MonoBehaviour
{
    private const string LeaderboardName = "Name";

    public event UnityAction PlayerAuthorized;
    public event UnityAction Completed;

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize(() => PlayerAccount.RequestPersonalProfileDataPermission());

        Completed?.Invoke();

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result != null)
                PlayerAuthorized?.Invoke();
        });
    }    
}
