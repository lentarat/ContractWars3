using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionSystem
{
    private FieldOfView _fieldOfView;
    public HumanStats CurrentSpottedPlayer { get; set; }

    public EnemyDetectionSystem(FieldOfView fieldOfView)
    {
        _fieldOfView = fieldOfView;
        //_fieldOfView.OnEnemyDetect
    }

    //public void SetCurrentSpottedPlayer(HumanStats enemy)
    //{
    //    CurrentSpottedPlayer = enemy;
    //}

    public bool HasPlayer()
    {
        CurrentSpottedPlayer = _fieldOfView.CheckForEnemies();
        if (CurrentSpottedPlayer != null)
        {
            return true;
        }
        return false;
    }
}
