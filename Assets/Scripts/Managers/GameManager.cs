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


//public class GameManager : MonoBehaviour
//{
//    [SerializeField] private GameObject _mapParent;
//    [SerializeField] private float _roundTime;

//    public System.Action<int,int> SecondElapsed;

//    private string _mapsPath = "Maps/";
//    private float _countdownTime;
//    private int _minutes;
//    private int _seconds;

//    private void Awake()
//    {
//        LoadMap();

//        _countdownTime = _roundTime;
//    }

//    private void Update()
//    {
//        _countdownTime -= Time.deltaTime;

//        _minutes = (int)(_countdownTime / 60f);
//        _seconds = (int)_countdownTime % 60;

//        if (_seconds != (int)_countdownTime)
//        {
//            SecondElapsed?.Invoke(_minutes, _seconds);
//        }
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

//}



public class GameManager : MonoBehaviour
{
    private GameManager() { }

    private static GameManager _instance;
    public static GameManager Instance { get => _instance; private set => _instance = value; }

    public GameState CurrentGameState { get; set; }

    [SerializeField] private GameObject _mapParent;
    [SerializeField] private float _roundTime;

    public System.Action<int, int> OnSecondElapsed;

    private string _mapsPath = "Maps/";
    private float _countdownTime;
    private int _minutes;
    private int _seconds;

    public enum GameState
    {
        MapChoose,
        Pause,
        Play
    }

    private void Awake()
    {
        Instance = this;

        LoadMap();

        _countdownTime = _roundTime;
    }

    private void Update()
    {
        if (CurrentGameState == GameState.Play)
        {
            _countdownTime -= Time.deltaTime;

            _minutes = (int)(_countdownTime / 60f);
            _seconds = (int)_countdownTime % 60;
            Debug.Log(_minutes);
            Debug.Log(_seconds);
            if (_seconds != (int)_countdownTime)
            {
                OnSecondElapsed?.Invoke(_minutes, _seconds);
            }
        }
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

