using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPlayer : MonoBehaviour
{
    public static DataPlayer instance;

    public string playerName;
    public string playerNameHighScore;
    public int highScore = 0;

    private Text highScoreText;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CalculateHighScore()
    {
        HighScore highScoreInstance = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<HighScore>();

        highScoreInstance.LoadData();

        highScoreText = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<Text>();

        highScoreText.text = "High Score - " + DataPlayer.instance.playerNameHighScore + ": " + DataPlayer.instance.highScore;
    }

    public void CalculateHighScore(int i)
    {
        highScoreText = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<Text>();
        HighScore highScoreInstance = GameObject.FindGameObjectWithTag("HighScoreText").GetComponent<HighScore>();

        highScoreInstance.LoadData();

        if (i > DataPlayer.instance.highScore)
        {
            highScoreText.text = "High Score - " + DataPlayer.instance.playerName + ": " + i;
            DataPlayer.instance.highScore = i;
            DataPlayer.instance.playerNameHighScore = DataPlayer.instance.playerName;
        }
        else if (DataPlayer.instance.highScore > i)
        {
            highScoreText.text = "High Score - " + DataPlayer.instance.playerNameHighScore + ": " + DataPlayer.instance.highScore;
        }
        
        highScoreInstance.SaveData();
    }   

}
