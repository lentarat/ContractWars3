using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float _timeToUpdateFov;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _radius;
    public float Radius { get => _radius; }
    [Range(0, 360)]
    [SerializeField] private float _angle;

    public System.Action OnEnemyDetected;

    private Vector3 _directionToEnemy;

    private HumanStats[] _playersOnTheMap;

    private int _humanLayerMask;
    private int _mapLayerMask;

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            return;
        }

        StartCoroutine(FovCoroutine());
        _humanLayerMask = LayerMask.NameToLayer("Human");
        _mapLayerMask = LayerMask.NameToLayer("Map");

        _playersOnTheMap = PlayerList.Instance.GetPlayersInRadius(transform.position, _radius);
    }

    private IEnumerator FovCoroutine()
    {
        float lastTimeUpdated = Time.time;
        while (true)
        {
            if (Time.time > lastTimeUpdated + _timeToUpdateFov)
            {
                lastTimeUpdated = Time.time;
                CheckForEnemies();
            }
            yield return null;
        }
    }

    public HumanStats CheckForEnemies()
    {
        foreach (var human in PlayerList.Instance.Players)
        {
            if(human.gameObject == gameObject)
            {
                continue;
            }
            
            _directionToEnemy = human.transform.position + Vector3.up - _camera.position;
            //Debug.Log(Vector3.Angle(transform.forward, _directionToEnemy));
            if (Vector3.Angle(transform.forward, _directionToEnemy) < _angle / 2f)
            {

                //if (!Physics.Raycast(transform.position, _directionToEnemy, _mapLayerMask))
                if (!Physics.Raycast(_camera.position, _directionToEnemy, _mapLayerMask))
                {
                    Debug.DrawLine(_camera.position, _camera.transform.position + _directionToEnemy * 50f);
                    OnEnemyDetected?.Invoke();
                    //Debug.Log("can see");
                    return human;
                }

            }
        }
        return null;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    //Gizmos.DrawLine(transform.position, transform.position + _directionToEnemy * 50f);
    //    Gizmos.DrawLine(_camera.position, _camera.transform.position + _directionToEnemy * 50f);
    //}
}