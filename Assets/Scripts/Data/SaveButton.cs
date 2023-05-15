using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    [SerializeField] private JsonReadWriteSystem _jsonData;
    [SerializeField] private Button _saveButton;

    void Start()
    {
        _saveButton.onClick.AddListener(_jsonData.SaveToJson);
    }


}
