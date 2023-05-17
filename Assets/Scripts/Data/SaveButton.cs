using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    [SerializeField] private SettingsController _settingsController;
    [SerializeField] private Button _saveButton;

    void Start()
    {
        _saveButton.onClick.AddListener(SaveSettingsData);
    }

    private void SaveSettingsData()
    {
        SettingsData settingsData = new SettingsData()
        {
            Music = _settingsController.Music.value,
            Sensitivity = _settingsController.Sensitivity.value,
            Volume = _settingsController.Volume.value
        };
        SaveSystem.Save(settingsData);
    }
}
