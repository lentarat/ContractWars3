using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "\\Saves\\";

    public SettingsData SettingsData { get; private set; }

    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    public static void Save<T>(T data)
    {
        string jsonData = JsonUtility.ToJson(data);

        int saveNumber = 1;

        while (File.Exists(SAVE_FOLDER + "save_" + saveNumber + ".txt"))
        {
            saveNumber++;
        }
        Debug.Log(SAVE_FOLDER + "save_" + saveNumber + ".txt");
        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + ".txt", jsonData);
    }

    public static T Load<T>()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER);
        FileInfo[] saveFiles = directoryInfo.GetFiles("*.txt");
        FileInfo mostRecentFile = null;

        string jsonData = null;

        foreach (FileInfo fileInfo in saveFiles)
        {
            if (mostRecentFile == null)
            {
                mostRecentFile = fileInfo;
            }
            else
            {
                if (fileInfo.LastWriteTime > mostRecentFile.LastWriteTime)
                {
                    mostRecentFile = fileInfo;
                }
            }
        }
        if (mostRecentFile == null)
        {
            return default(T);
        }
        else
        {
            jsonData = File.ReadAllText(mostRecentFile.FullName);
        }
        return JsonUtility.FromJson<T>(jsonData);
    }
}
