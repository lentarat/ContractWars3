using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _mapParent;
    private string _mapsPath = "Maps/";

    private void Awake()
    {
        //LoadMap();
    }

    private void LoadMap()
    {
        var maps =_mapParent.GetComponentsInChildren<Renderer>();
        foreach (var go in maps)
        {
            Destroy(go.gameObject);
        }
        Instantiate(Resources.Load(_mapsPath + MapChoose.ChosenMapName), _mapParent.transform).name = MapChoose.ChosenMapName;
    }
}
