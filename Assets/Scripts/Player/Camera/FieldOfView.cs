using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private float _radius;
    public float Radius { get => _radius; }
    [Range(0, 360)]
    [SerializeField] private float _angle;

    private int _humanLayerMask;
    private int _obstacleLayerMask;

    private void Awake()
    {
        _humanLayerMask = LayerMask.NameToLayer("Human");
        _obstacleLayerMask = LayerMask.NameToLayer("Obstacle");
    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, _humanLayerMask);

        //if (colliders.Length > 0)
        //{
        //    Vector3 _directionToEnemy
        //    Vector3.Angle(transform.forward, )
        //}
        foreach (var human in colliders)
        {
            Vector3 _directionToEnemy = human.transform.position - transform.position;
            Debug.Log(Vector3.Angle(transform.forward, _directionToEnemy));
            if (Vector3.Angle(transform.forward, _directionToEnemy) < _angle / 2f)
            {
                if (!Physics.Raycast(transform.position, _directionToEnemy, _obstacleLayerMask))
                {
                    Debug.Log("can see");
                }
            }
        }
    }
}
