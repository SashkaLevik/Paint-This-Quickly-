using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agava.YandexGames;

public class LeaderboardView : MonoBehaviour
{
    private const string LeaderboardName = "Leaderboard";

    [SerializeField] private Score _score;
    [SerializeField] private PlayerData _playerDataTamplate;
    [SerializeField] private Transform _table;
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private GameObject _leaderboardPanel;
    [SerializeField] private Button _return;

    private List<PlayerData> _playerDatas = new List<PlayerData>();

    private void OnEnable()
    {
        _menuScreen.LeaderboardOpened += LoadLeaderboard;
        _return.onClick.AddListener(Return);
    }

    private void OnDisable()
    {
        _menuScreen.LeaderboardOpened -= LoadLeaderboard;
        _return.onClick.RemoveListener(Return);
    }

    private void LoadLeaderboard()
    {
        if (YandexGamesSdk.IsInitialized == false)
            return;

        _leaderboardPanel.SetActive(true);
        Autorize();
        SetScore();
        ClearLeaderboard();

        Agava.YandexGames.Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            foreach (var entry in result.entries)
            {
                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "Anonymus";

                PlayerData playerData = Instantiate(_playerDataTamplate, _table);
                playerData.Initialize(name, entry.rank, entry.score);
                _playerDatas.Add(playerData);
            }
        });
    }

    private void Autorize()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();

        if (PlayerAccount.IsAuthorized == false)
            PlayerAccount.Authorize();
    }

    private void SetScore()
    {
        if (PlayerAccount.IsAuthorized == false)
            return;

        Agava.YandexGames.Leaderboard.SetScore(LeaderboardName, _score.TotalScore);
    }

    private void ClearLeaderboard()
    {
        foreach (PlayerData entry in _playerDatas)
            Destroy(entry.gameObject);

        _playerDatas = new List<PlayerData>();
    }    

    private void Return()
    {
        _leaderboardPanel.SetActive(false);
    }
}
