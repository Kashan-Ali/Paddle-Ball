using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string playername;
    public string bestName;
    public int highScore;
    
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

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public void SaveHighScore(int bestScore, string BestName)
    {
        SaveData data = new SaveData();
        data.highScore = bestScore;
        data.playerName = BestName;

        string createData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", createData);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string readData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(readData);

            highScore = data.highScore;
            bestName = data.playerName;
        }
    }

    public void ShowHighScore(Text bestScore)
    {
        LoadHighScore();
        bestScore.text = "High Score:" + bestName + " : " + highScore;
    }
}
