using UnityEngine;

public class LeaderboardView : MonoBehaviour
{
    [SerializeField] private YandexLBLoader _yandexLBLoader;

    private FillPlayerData[] _fillPlayerDatas;
    private LeaderboardPlayers[] _players;

    private void OnEnable()
    {
        _fillPlayerDatas = GetComponentsInChildren<FillPlayerData>();

        _players = _yandexLBLoader.Players;

        for (int i = 0; i < _players.Length; i++)
        {
            if (_fillPlayerDatas[i] != null)
            {
                _fillPlayerDatas[i].SetData(_players[i]);
            }
        }

        enabled = false;
    }
}
