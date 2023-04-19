using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // switch between players when death mode
    [SerializeField] private List<Player> _playerList;

    private WeaponManager _bulletsManager;
}
