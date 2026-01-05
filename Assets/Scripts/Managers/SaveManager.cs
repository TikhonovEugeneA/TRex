using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class SaveManager : MonoBehaviour
{
    [Header("Game data")] 
    [Tooltip("Game data structure.")]
    [SerializeField] private GameData gameData;

    [Header("Settings")] 
    [Tooltip("Save file name.")]
    [SerializeField] private string saveFileName;
        
    [Tooltip("Save directory name.")]
    [SerializeField] private string saveDirectoryName;
        
    [Tooltip("Path to save directory.")]
    [SerializeField] private string saveDirectoryPath;
        
    [Tooltip("Path to save file.")]
    [SerializeField] private string saveFilePath;

    [SerializeField] private UnityEvent<GameData> dataLoaded;
    [SerializeField] private UnityEvent<GameData> dataSaved;

    public void OnRestartLevel()
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath,json);
        dataSaved?.Invoke(gameData);
    }

    private void Awake()
    {
#if UNITY_ANDROID
        saveDirectoryPath = Path.Combine(Application.persistentDataPath, saveDirectoryName);
        saveFilePath = Path.Combine(Application.persistentDataPath, saveDirectoryName,saveFileName);
#endif        

#if UNITY_STANDALONE || UNITY_EDITOR
        saveDirectoryPath = Path.Combine(Application.dataPath, saveDirectoryName);
        saveFilePath = Path.Combine(Application.dataPath, saveDirectoryName,saveFileName);
#endif
        if(Directory.Exists(saveDirectoryPath) == false)
        {
            Directory.CreateDirectory(saveDirectoryPath);

        }

        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData gameDataFromJson = JsonUtility.FromJson<GameData>(json);
            this.gameData = gameDataFromJson;
            dataLoaded?.Invoke(this.gameData);
        }
    }

    public void OnHighScoreChanged(int highScore)
    {
        gameData.highScoreCount = highScore;
    }
}
