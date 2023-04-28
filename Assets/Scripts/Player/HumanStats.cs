using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStats : MonoBehaviour
{
    [SerializeField] private int _hp;
    public int Hp { get => _hp;
        set
        {
            _hp = value;
            if (_hp < 0)
            {
                _hp = 0;
                Destroy(gameObject);
            }
        }
    }
    [SerializeField] private int _armor;
    public int Armor { get => _armor;
        set
        {
            _armor = value;
            if (_armor < 0)
            {
                _armor = 0;
            }
        }
    }
}
