using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public class GameManager : MonoBehaviour
//{
//    private GameManager() { }

//    private static GameManager _instance;
//    public static GameManager Instance { get => _instance; }

//    [SerializeField] private GameObject _mapParent;
//    private string _mapsPath = "Maps/";

//    private void Awake()
//    {
//        _instance = this;
//        LoadMap();
//    }

//    private void LoadMap()
//    {
//        var maps = _mapParent.GetComponentsInChildren<Renderer>();
//        foreach (var go in maps)
//        {
//            Destroy(go.gameObject);
//        }
//        Instantiate(Resources.Load(_mapsPath + MapChoose.ChosenMapName), _mapParent.transform).name = MapChoose.ChosenMapName;
//    }

//    public void Test()
//    {
//        Debug.Log("test");
//    }
//}


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _mapParent;
    private string _mapsPath = "Maps/";

    private void Awake()
    {
        LoadMap();
    }

    private void LoadMap()
    {
        var maps = _mapParent.GetComponentsInChildren<Renderer>();
        foreach (var go in maps)
        {
            Destroy(go.gameObject);
        }
        Instantiate(Resources.Load(_mapsPath + MapChoose.ChosenMapName), _mapParent.transform).name = MapChoose.ChosenMapName;
    }

}
