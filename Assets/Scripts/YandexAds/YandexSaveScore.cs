using Agava.YandexGames;
using UnityEngine;

public class YandexSaveScore : MonoBehaviour
{
    private const string LeaderboardName = "Name";

    [SerializeField] private Score _score;

    private void OnEnable()
    {
        if (_score.TotalScore == 0)
            return;

        Leaderboard.GetPlayerEntry(LeaderboardName, (result) =>
        {
            if (result == null)
            {
                Leaderboard.SetScore(LeaderboardName, _score.TotalScore);
            }
            else
            {
                if (result.score < _score.TotalScore)
                    Leaderboard.SetScore(LeaderboardName, _score.TotalScore);
            }
        });
    }
}
