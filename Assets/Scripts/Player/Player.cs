using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //must be used while making player scroll death camera
    [SerializeField] private bool _showUIOfThisPlayer;
    public bool ShowUIOfThisPlayer { get => _showUIOfThisPlayer; set => _showUIOfThisPlayer = value; }

    private void Awake()
    {
        if (_showUIOfThisPlayer)
        {
            
        }
    }
}
