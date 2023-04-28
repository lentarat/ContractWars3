using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStats : MonoBehaviour
{
    [SerializeField] private int _hp;
    public int Hp { get => _hp; set => _hp = value; }
    [SerializeField] private int _armor;
    public int Armor { get => _armor; set => _armor = value; }
}
