using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsController : MonoBehaviour
{
    [SerializeField] private Slider _volume;
    public Slider Volume { get => _volume; }

    [SerializeField] private Slider _music;
    public Slider Music { get => _music; }

    [SerializeField] private Slider _sensitivity;
    public Slider Sensitivity { get => _sensitivity; }
}
