using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScore : MonoBehaviour
{
    private void Start()
    {
        DataPlayer.instance.CalculateHighScore();
    }

    public class PlayerDataForSave
    {
        public string playerNameHighScore;
        public int highScore;
    }

    public void SaveData()
    {
        PlayerDataForSave playerDataForSave = new PlayerDataForSave
        {
            playerNameHighScore = DataPlayer.instance.playerNameHighScore,
            highScore = DataPlayer.instance.highScore
        };

        string json = JsonUtility.ToJson(playerDataForSave);
        File.WriteAllText(Application.dataPath + "/Save.text", json);
    }

    public void LoadData()
    { 
        if (File.Exists(Application.dataPath + "/Save.text"))
        {
            string loadJson = File.ReadAllText(Application.dataPath + "/Save.text");

            PlayerDataForSave dataLoaded = JsonUtility.FromJson<PlayerDataForSave>(loadJson);

            DataPlayer.instance.playerNameHighScore = dataLoaded.playerNameHighScore;
            DataPlayer.instance.highScore = dataLoaded.highScore;
        }
    }
}