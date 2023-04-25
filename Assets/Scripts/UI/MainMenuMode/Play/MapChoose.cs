using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapChoose : MonoBehaviour
{
    [SerializeField] private GameObject _mapsParent;
    
    void Awake()
    {
        Button[] maps = _mapsParent.GetComponentsInChildren<Button>();
        foreach (Button button in maps)
        {
            /*button.onClick.AddListener(() => LoadMap(ScenesManager.Scene.Map1));*/  //////////////////////????????????
        }
    }

    private void LoadMap(ScenesManager.Scene map)
    {
        ScenesManager.Instance.LoadScene(map);
    }
}
