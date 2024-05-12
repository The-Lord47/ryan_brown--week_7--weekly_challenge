using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    public int highScore;
    public string highScorePlayerName;
    public string currentPlayerName;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        loadHighscore();
    }

    [System.Serializable]
    class saveData
    {
        public int highScore;
        public string highScorePlayerName;
    }

    public void saveHighscore()
    {
        saveData data = new saveData();
        data.highScore = highScore;
        data.highScorePlayerName = highScorePlayerName;

        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscore_data.json", jsonData);
    }

    public void loadHighscore()
    {
        string path = Application.persistentDataPath + "/highscore_data.json";
        string jsonData = File.ReadAllText(path);

        saveData data = JsonUtility.FromJson<saveData>(jsonData);

        highScore = data.highScore;
        highScorePlayerName = data.highScorePlayerName;
    }
}
