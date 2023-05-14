using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private GameManager() { }

    private static GameManager _instance;
    public static GameManager Instance { get => _instance; private set => _instance = value; }

    [SerializeField] private GameObject _mapParent;
    [SerializeField] private float _roundTime;

    public System.Action<int, int> OnSecondElapsed;
    //public System.Action OnTimerCountdownOver;
    public System.Action<int, int> OnSomeoneKilled;

    public GameState CurrentGameState { get; set; }
    public int TerroristsKilled { get; set; }
    public int CounterTerroristsKilled { get; set; }


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

            if (_countdownTime < 0f)
            {
                //OnTimerCountdownOver?.Invoke();
            }

            if (_seconds != (int)_countdownTime)
            {
                FormatTime();
                OnSecondElapsed?.Invoke(_minutes, _seconds);
            }

            FormatTime();
        }
    }

    public void UpdateKillCounter(bool isTerroristKilled, bool isCounterTerroristKilled)
    {
        //OnSomeoneKilled?.Invoke(CounterTerroristsKilled + (isCounterTerroristKilled ? 1 : 0 ), TerroristsKilled + (isTerroristKilled ? 1 : 0));
        CounterTerroristsKilled += isCounterTerroristKilled ? 1 : 0;
        TerroristsKilled += isTerroristKilled ? 1 : 0;
        OnSomeoneKilled?.Invoke(CounterTerroristsKilled , TerroristsKilled);
    }

    private void FormatTime()
    {
        _minutes = (int)(_countdownTime / 60f);
        _seconds = (int)_countdownTime % 60;
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

