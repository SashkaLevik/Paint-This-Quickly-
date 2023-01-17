using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public float speedLevel;
    public float tankLevel;
    public int money;

    public GameData(Player player)
    {
        speedLevel = player.MoveSpeed;
    }


}
