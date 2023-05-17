using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView 
{
    private float _angle = 75f;
    private Vector3 _headOffset = new Vector3(0f, 0.8f, 0f);
    private int _humanLayerMask = LayerMask.NameToLayer("Human");

    public HumanStats CheckForEnemies(Transform me, HumanStats.Unit _teamUnit)
    {
        foreach (var human in PlayerList.Instance.Players)
        {
            if (_teamUnit == human.TeamUnit || me.gameObject == human.gameObject)
            {
                continue;
            }

            Vector3 _directionToEnemy = human.transform.position + _headOffset - me.position;

            if (Vector3.Angle(me.forward, _directionToEnemy) < _angle / 2f)
            {
                RaycastHit raycastHit;
                if (Physics.Raycast(me.position, _directionToEnemy, out raycastHit))
                {
                    if (raycastHit.collider.gameObject.layer == _humanLayerMask)
                    {
                        return human;
                    }
                }
            }
        }
        return null;
    }
}