using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionSystem
{
    private FieldOfView _fieldOfView = new FieldOfView();
    private HumanStats _lastSpottedPlayer { get; set; }

    public HumanStats GetLastSpottedEnemy(Transform me, HumanStats.Unit _teamUnit)
    {
        return _fieldOfView.CheckForEnemies(me, _teamUnit);
    }

    public bool HasPlayer(Transform me, HumanStats.Unit _teamUnit)
    {
        _lastSpottedPlayer = _fieldOfView.CheckForEnemies(me, _teamUnit);
        if (_lastSpottedPlayer == null)
        {
            return false;
        }
        return true;
    }
}
