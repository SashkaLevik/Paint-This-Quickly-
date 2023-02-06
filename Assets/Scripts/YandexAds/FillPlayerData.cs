using TMPro;
using UnityEngine;

public class FillPlayerData : MonoBehaviour
{
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;

    public void SetData(LeaderboardPlayers player)
    {
        _rank.text = player.Rank.ToString();

        if (player.Rank == 0)
        {
            _rank.text = "-";
        }

        _name.text = player.Name.ToString();
        _score.text = player.Score.ToString();
    }
}
