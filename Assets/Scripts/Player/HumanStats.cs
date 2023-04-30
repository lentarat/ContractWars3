using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStats : MonoBehaviour
{
    [SerializeField] private int _hp;
    public int Hp { get => _hp;
        set
        { 
            if(Armor > 0 )
            {
                _hp = (int)(value * 0.85f);
                Debug.Log(_hp);
                Armor -= (int)(_armor * 0.1f); 
            }
            if (_hp < 0)
            {
                _hp = 0;
                Destroy(gameObject);

            }
            OnHPChanged?.Invoke();
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
            OnArmorChanged?.Invoke();
        }
    }

    public Action OnHPChanged;

    public Action OnArmorChanged;
}
