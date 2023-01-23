using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Upgrades _upgrades;
    [SerializeField] private Player _player;
    [SerializeField] private Tank _tank;
    [SerializeField] private FoodSpawner _foodSpawner;

    private const string SpeedKey = "Speed";
    private const string SpeedLevelKey = "SpeedLevel";
    private const string TankKey = "Tank";
    private const string TankLevelKey = "TankLevel";
    private const string MoneyKey = "Money";
    private const string CurrentLevel = "CurrentLevel";

    public void Save()
    {
        PlayerPrefs.SetInt(MoneyKey, _upgrades.Money);
        PlayerPrefs.SetInt(SpeedLevelKey, _upgrades.SpeedLevel);
        PlayerPrefs.SetInt(TankLevelKey, _upgrades.TankLevel);
        PlayerPrefs.SetFloat(SpeedKey, _player.MoveSpeed);
        PlayerPrefs.SetFloat(TankKey, _tank.FullTank);
        PlayerPrefs.SetInt(CurrentLevel, _foodSpawner.CurrentLevel);
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
        }
        else
            Debug.Log("Save not found");
    }

    //public void Save(GameData data)
    //{
    //    PlayerPrefs.SetFloat(SpeedKey, data.Speed);
    //    //PlayerPrefs.SetFloat(TankKey, data.tankLevel);
    //    PlayerPrefs.SetInt(MoneyKey, data.Money);
    //    PlayerPrefs.Save();
    //    Debug.Log("Save");
    //}

    //public GameData Load()
    //{
    //    var data = new GameData();

    //    if (PlayerPrefs.HasKey(MoneyKey))
    //    {
    //        data.Speed = PlayerPrefs.GetFloat(SpeedKey);
    //        //data.tankLevel = PlayerPrefs.GetFloat(TankKey);
    //        data.Money = PlayerPrefs.GetInt(MoneyKey);
    //    }
    //    else
    //        Debug.Log("NotFound");
    //    return data;
    //}
}
