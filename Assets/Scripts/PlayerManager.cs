using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public string playerName;
    public string bestPlayerName;
    public int bestScore;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestResult();
    }
    
    public void CommitBestResult(string name, int score)
    {
        bestPlayerName = name;
        bestScore = score;
        SaveBestResult();
    }

    

    [System.Serializable]
    class SaveData
    {
        public string bestName;
        public int bestScore;
    }
    public void SaveBestResult() {
        SaveData data = new SaveData();
        data.bestName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestResult()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.bestName;
            bestScore = data.bestScore;
        }
    }
}
