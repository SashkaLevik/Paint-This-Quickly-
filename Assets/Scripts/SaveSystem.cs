using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private Player _player;
    [SerializeField] private Tank _tank;
    [SerializeField] private FoodSpawner _foodSpawner;
    [SerializeField] private Score _score;

    private const string SpeedKey = "Speed";
    private const string SpeedLevelKey = "SpeedLevel";
    private const string TankKey = "Tank";
    private const string TankLevelKey = "TankLevel";
    private const string MoneyKey = "Money";
    private const string CurrentLevel = "CurrentLevel";
    private const string TotalScore = "TotalScore";

    public void Save()
    {
        PlayerPrefs.SetInt(MoneyKey, _upgrades.Money);
        PlayerPrefs.SetInt(SpeedLevelKey, _upgrades.SpeedLevel);
        PlayerPrefs.SetInt(TankLevelKey, _upgrades.TankLevel);
        PlayerPrefs.SetFloat(SpeedKey, _player.MoveSpeed);
        PlayerPrefs.SetFloat(TankKey, _tank.FullTank);
        PlayerPrefs.SetInt(CurrentLevel, _foodSpawner.CurrentLevel);
        PlayerPrefs.SetInt(TotalScore, _score.TotalScore);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(MoneyKey))
        {
            _upgrades.InitMoney(PlayerPrefs.GetInt(MoneyKey));
            _upgrades.InitSpeed(PlayerPrefs.GetInt(SpeedLevelKey));
            _upgrades.InitTank(PlayerPrefs.GetInt(TankLevelKey));
            _player.Init(PlayerPrefs.GetFloat(SpeedKey));
            _tank.Init(PlayerPrefs.GetFloat(TankKey));
            _foodSpawner.Init(PlayerPrefs.GetInt(CurrentLevel));
            _score.Init(PlayerPrefs.GetInt(TotalScore));
        }
        else
            Debug.Log("Save not found");
    }    
}
