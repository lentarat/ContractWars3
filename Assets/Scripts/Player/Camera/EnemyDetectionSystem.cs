using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectionSystem : MonoBehaviour
{
    [SerializeField] private FieldOfView _fieldOfView;

    public HumanStats CurrentSpottedPlayer { get; set; }

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
