using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayers
{
    private static HumanStats[] _players;
    public static void SetPlayersOnTheMap(HumanStats[] players)
    {
        _players = players;
    }

    public static HumanStats GetClosestPlayer(Vector3 from)
    {
        float closestDistance = float.MaxValue;
        HumanStats closestPlayer = null;
        foreach (HumanStats player in _players)
        {
            float currentDistance = Vector3.Distance(player.transform.position, from);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestPlayer = player;
            }
        }
        return closestPlayer;
    }

    public static HumanStats[] GetPlayersInRadius(Vector3 from, float radius)
    {
        List<HumanStats> players = new List<HumanStats>();
        foreach (HumanStats player in _players)
        {
            if (from == player.transform.position)
            {
                continue;
            }
            //Debug.Log(Vector3.Distance(player.transform.position, from));
            if (Vector3.Distance(player.transform.position, from) < radius)
            {
                players.Add(player);
            }
        }
        return players.ToArray();
    }
}
