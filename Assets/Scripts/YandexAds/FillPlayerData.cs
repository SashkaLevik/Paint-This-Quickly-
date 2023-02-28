using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillPlayerData : MonoBehaviour
{

    //[SerializeField] private TMP_Text _rank;
    //[SerializeField] private TMP_Text _name;
    //[SerializeField] private TMP_Text _score;
    [SerializeField] private GameObject _rowPrefab;
    [SerializeField] private Transform _rowParent;

    public void SetData(LeaderboardPlayers player)
    {
        GameObject newRow = Instantiate(_rowPrefab, _rowParent);
        Text[] texts = newRow.GetComponentsInChildren<Text>();
        texts[0].text = player.Rank.ToString();

        if (player.Rank == 0)
        {
            texts[0].text = "-";
        }

        texts[1].text = player.Name;
        texts[2].text = player.Score.ToString();

        //_rank.text = player.Rank.ToString();

        //if (player.Rank == 0)
        //{
        //    _rank.text = "-";
        //}

        //_name.text = player.Name;
        //_score.text = player.Score.ToString();
    }
}
