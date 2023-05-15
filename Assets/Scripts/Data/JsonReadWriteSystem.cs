using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class JsonReadWriteSystem : MonoBehaviour
{
    private JsonReadWriteSystem() { }

    private static JsonReadWriteSystem _instance;
    
    public static JsonReadWriteSystem Instance
    {
        get 
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    [SerializeField] private Slider _volume;
    public Slider Volume { get { return _volume; } }

    [SerializeField] private Slider _music;
    public Slider Music { get { return _music; } }

    [SerializeField] private Slider _sensitivity;
    public Slider Sensitivity { get { return _sensitivity; } }


    private void Awake()
    {
        Instance = this;
        LoadFromJson();
    }
    public void SaveToJson()
    {
        SettingsData data = new SettingsData();
        data.Volume = _volume.value;
        data.Music = _music.value;
        data.Sensitivity = _sensitivity.value;

        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.dataPath + "/SettingData.json", json);

    }

    public void LoadFromJson()
    {
        string json = System.IO.File.ReadAllText(Application.dataPath + "/SettingData.json");
        SettingsData data = JsonUtility.FromJson<SettingsData>(json);

        _volume.value = data.Volume;
        _music.value = data.Music;
        _sensitivity.value = data.Sensitivity;
    }

}
