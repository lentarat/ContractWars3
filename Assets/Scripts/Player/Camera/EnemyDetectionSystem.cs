using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionSystem
{
    private FieldOfView _fieldOfView;
    private HumanStats _lastSpottedPlayer { get; set; }

    public EnemyDetectionSystem(FieldOfView fieldOfView)
    {
        _fieldOfView = fieldOfView;
        //_fieldOfView.OnEnemyDetect
    }

    //public void SetCurrentSpottedPlayer(HumanStats enemy)
    //{
    //    CurrentSpottedPlayer = enemy;
    //}

    public HumanStats GetLastSpottedEnemy()
    {
        return _fieldOfView.CheckForEnemies();
    }

    public bool HasPlayer()
    {
        _lastSpottedPlayer = _fieldOfView.CheckForEnemies();
        if (_lastSpottedPlayer == null)
        {
            return false;
        }
        Debug.Log("enemy spotted");
        return true;
    }
}
