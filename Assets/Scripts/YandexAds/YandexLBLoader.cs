using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class YandexLBLoader : MonoBehaviour
{
    private const int MaxAmount = 6;
    private const string Anonimus = "Anonimus";
    private const string LeaderboardName = "Leaderboard";

    [SerializeField] private YandexInitialization _yandexInitialization;

    private List<LeaderboardPlayers> _players;

    public LeaderboardPlayers[] Players => _players.ToArray();

    private void OnEnable()
    {
        _yandexInitialization.PlayerAuthorized += OnAutorized;
    }

    private void OnAutorized()
    {
        _players = new List<LeaderboardPlayers>();

        Leaderboard.GetEntries(LeaderboardName, (result) =>
        {
            for (int i = 0; i < MaxAmount; i++)
            {
                LeaderboardPlayers leaderboardPlayers = new LeaderboardPlayers();

                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = Anonimus;

                leaderboardPlayers.SetValue(result.entries[i].rank, name, result.entries[i].score);
                _players.Add(leaderboardPlayers);
            }
        });
    }
}
