using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{        
    public static void SaveGame(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/Save.data";
        FileStream stream = new FileStream(filePath, FileMode.Create);
        GameData data = new GameData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame()
    {
        string filePath = Application.persistentDataPath + "/Save.data";

        if (File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Save not found" + filePath);
            return null;
        }
    }    
}
