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

    //[SerializeField] private YandexLBLoader _yandexLBLoader;
    //[SerializeField] private Button _returnToMenu;
    //[SerializeField] private MenuScreen _menuScreen;
    //[SerializeField] private GameObject LBPanel;

    //private FillPlayerData[] _fillPlayerDatas;
    //private LeaderboardPlayers[] _players;    

    //private void OnEnable()
    //{
    //    _menuScreen.LBOpened += Show;
    //    _returnToMenu.onClick.AddListener(Return);
    //    //enabled = false;
    //}

    //private void OnDisable()
    //{
    //    _menuScreen.LBOpened -= Show;
    //    _returnToMenu.onClick.RemoveListener(Return);
    //}

    //private void Show()
    //{
    //    LBPanel.SetActive(true);
    //    _fillPlayerDatas = GetComponentsInChildren<FillPlayerData>();

    //    _players = _yandexLBLoader.Players;

    //    for (int i = 0; i < _players.Length; i++)
    //    {
    //        if (_fillPlayerDatas[i] != null)
    //        {
    //            _fillPlayerDatas[i].SetData(_players[i]);
    //        }
    //    }
    //}

    private void Return()
    {
        _leaderboardPanel.SetActive(false);
    }
}
