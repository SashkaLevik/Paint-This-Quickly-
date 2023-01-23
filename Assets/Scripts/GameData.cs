using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public float Speed = 4;
    public int Money;

    //private const string SpeedKey = "Speed";
    //private const string SpeedLevelKey = "SpeedLevel";
    //private const string TankKey = "TankCapacity";
    //private const string MoneyKey = "Money";

    //[SerializeField] private Player _player;
    //[SerializeField] private Tank _tank;
    //[SerializeField] private Upgrades _upgrades;

    //private float _defaultSpeed = 4;

    //public float Speed => PlayerPrefs.GetFloat(SpeedKey);
    //public float SpeedLevel => PlayerPrefs.GetFloat(SpeedLevelKey);
    //public int Money => PlayerPrefs.GetInt(MoneyKey);

    //private void Start()
    //{
    //    if (!PlayerPrefs.HasKey(SpeedKey))
    //    {
    //        PlayerPrefs.SetFloat(SpeedKey, _defaultSpeed);
    //    }
    //}

    //private void OnEnable()
    //{
    //    _upgrades.MoneyChanged += OnMoneyChanged;
    //    _upgrades.SpeedLevelUp += OnSpeedLevelChanged;
    //    _player.SpeedUp += OnSpeedChanged;
    //}

    //private void OnDisable()
    //{
    //    _upgrades.MoneyChanged -= OnMoneyChanged;
    //    _player.SpeedUp -= OnSpeedChanged;
    //}

    //private void OnSpeedChanged(float speed)
    //{
    //    PlayerPrefs.SetFloat(SpeedKey, speed);
    //    //Debug.Log("SpeedChanged");
    //}

    //private void OnSpeedLevelChanged(float speedLevel)
    //{
    //    PlayerPrefs.SetFloat(SpeedLevelKey, speedLevel);
    //}

    //private void OnMoneyChanged(int money)
    //{
    //    PlayerPrefs.SetInt(MoneyKey, money);
    //}
    //public static void Save(GameData data)
    //{
    //    PlayerPrefs.SetFloat(SpeedKey, data.speedLevel);
    //    PlayerPrefs.SetFloat(TankKey, data.tankLevel);
    //    PlayerPrefs.SetInt(MoneyKey, data.money);
    //    PlayerPrefs.Save();
    //}

    //public static GameData Load()
    //{
    //    var data = new GameData();

    //    if (PlayerPrefs.HasKey(SpeedKey))
    //    {
    //        data.speedLevel = PlayerPrefs.GetFloat(SpeedKey);
    //        data.tankLevel = PlayerPrefs.GetFloat(TankKey);
    //        data.money = PlayerPrefs.GetInt(MoneyKey);
    //    }
    //    return data;
    //}

    //public static void SaveGame(Player player)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();
    //    string filePath = Application.persistentDataPath + "/Save.data";
    //    FileStream stream = new FileStream(filePath, FileMode.Create);
    //    GameData data = new GameData(player);
    //    formatter.Serialize(stream, data);
    //    stream.Close();
    //}

    //public static GameData LoadGame()
    //{
    //    string filePath = Application.persistentDataPath + "/Save.data";

    //    if (File.Exists(filePath))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream(filePath, FileMode.Open);
    //        GameData data = formatter.Deserialize(stream) as GameData;
    //        stream.Close();
    //        return data;
    //    }
    //    else
    //    {
    //        Debug.Log("Save not found" + filePath);
    //        return null;
    //    }
    //}
}
