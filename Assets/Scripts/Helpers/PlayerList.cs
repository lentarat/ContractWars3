using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerList
{
    private PlayerList() { }

    private static PlayerList _instance;
    
    public static PlayerList Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerList();
            }
            return _instance;
        }
    }

    //is assigned in PlayerListCreator
    private List<HumanStats> _players = new List<HumanStats>();
    public List<HumanStats> Players { get => _players; }
    private List<HumanStats> _playersInRadius = new List<HumanStats>();

    public void SetPlayersOnTheMap(HumanStats[] players)
    {
        _players.AddRange(players);
    }

    public HumanStats GetClosestPlayer(Vector3 from)
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

    public HumanStats[] GetPlayersInRadius(Vector3 from, float radius)
    {
        foreach (HumanStats player in _players)
        {
            if (from == player.transform.position)
            {
                continue;
            }
            if (Vector3.Distance(player.transform.position, from) < radius)
            {
                _playersInRadius.Add(player);
            }
        }
        return _playersInRadius.ToArray();
    }

    public void RemovePlayer()
    {
        _players.RemoveAll(item => item == null);
        Debug.Log(_players.Count);
    }
    public void RemovePlayer(HumanStats player)
    {
        _players.Remove(player);
    }

    //public static HumanStats[] GetPlayersInRadius(ref HumanStats[] players, Vector3 from, float radius)
    //{
    //    foreach (HumanStats player in _players)
    //    {
    //        if (from == player.transform.position)
    //        {
    //            continue;
    //        }
    //        //Debug.Log(Vector3.Distance(player.transform.position, from));
    //        if (Vector3.Distance(player.transform.position, from) < radius)
    //        {
    //            players.Add(player);
    //        }
    //    }
    //    return players.ToArray();
    //}

}


//public class PlayerList
//{
//    private static HumanStats[] _players;
//    public static void SetPlayersOnTheMap(HumanStats[] players)
//    {
//        _players = players;
//    }

//    public static HumanStats GetClosestPlayer(Vector3 from)
//    {
//        float closestDistance = float.MaxValue;
//        HumanStats closestPlayer = null;
//        foreach (HumanStats player in _players)
//        {
//            float currentDistance = Vector3.Distance(player.transform.position, from);
//            if (currentDistance < closestDistance)
//            {
//                closestDistance = currentDistance;
//                closestPlayer = player;
//            }
//        }
//        return closestPlayer;
//    }

//    //public static HumanStats[] GetPlayersInRadius(Vector3 from, float radius)
//    //{
//    //    List<HumanStats> players = new List<HumanStats>();
//    //    foreach (HumanStats player in _players)
//    //    {
//    //        if (from == player.transform.position)
//    //        {
//    //            continue;
//    //        }
//    //        //Debug.Log(Vector3.Distance(player.transform.position, from));
//    //        if (Vector3.Distance(player.transform.position, from) < radius)
//    //        {
//    //            players.Add(player);
//    //        }
//    //    }
//    //    return players.ToArray();
//    //}

//    public static HumanStats[] GetPlayersInRadius(ref HumanStats[] players, Vector3 from, float radius)
//    {
//        foreach (HumanStats player in _players)
//        {
//            if (from == player.transform.position)
//            {
//                continue;
//            }
//            //Debug.Log(Vector3.Distance(player.transform.position, from));
//            if (Vector3.Distance(player.transform.position, from) < radius)
//            {
//                players.Add(player);
//            }
//        }
//        return players.ToArray();
//    }

//}
