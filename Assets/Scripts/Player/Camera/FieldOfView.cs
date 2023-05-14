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
    [SerializeField] private Vector3 _headOffset;

    //public System.Action OnEnemyDetected;

    private Vector3 _directionToEnemy;
    private int _mapLayerMask;
    private HumanStats.Unit _teamUnit;

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            return;
        }

        _teamUnit = gameObject.GetComponent<HumanStats>().TeamUnit;
        //StartCoroutine(FovCoroutine());
        //_humanLayerMask = LayerMask.NameToLayer("Human");
        _mapLayerMask = LayerMask.NameToLayer("Map");
    }

    //private IEnumerator FovCoroutine()
    //{
    //    float lastTimeUpdated = Time.time;
    //    while (true)
    //    {
    //        if (Time.time > lastTimeUpdated + _timeToUpdateFov)
    //        {
    //            lastTimeUpdated = Time.time;
    //            CheckForEnemies();
    //        }
    //        yield return null;
    //    }
    //}

    public HumanStats CheckForEnemies()
    {
        foreach (var human in PlayerList.Instance.Players)
        {
            if(human == null || human.gameObject == gameObject || _teamUnit == human.TeamUnit  )
            {
                continue;
            }
            
            _directionToEnemy = human.transform.position + _headOffset - transform.position;
            //Debug.Log(Vector3.Angle(transform.forward, _directionToEnemy));
            if (Vector3.Angle(transform.forward, _directionToEnemy) < _angle / 2f)
            {
                if (!Physics.Raycast(transform.position + _headOffset, _directionToEnemy, _mapLayerMask))
                {
                    //OnEnemyDetected?.Invoke();
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