using UnityEngine;
using System.IO;

public class PlayerData
{
    public string playerName;
    public int highScore;

    public PlayerData(string name, int score)
    {
        playerName = name;
        highScore = score;
    }
}

public class DataManager : MonoBehaviour
{
    private static string filePath => Path.Combine(Application.persistentDataPath, "playerData.json");
    public static PlayerData CurrentData { get; private set; }

    public static void SaveData(PlayerData data)
    {
        CurrentData = data;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public static void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            CurrentData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            CurrentData = new PlayerData("Player", 0);
        }
    }
}
