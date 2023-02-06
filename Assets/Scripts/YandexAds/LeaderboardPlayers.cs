
public class LeaderboardPlayers
{
    public string Name { get; private set; }
    public int Rank { get; private set; }
    public int Score { get; private set; }

    public void SetValue(int rank, string name, int score)
    {
        Name = name;
        Rank = rank;
        Score = score;
    }
}
