using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStats : MonoBehaviour
{
    public Action OnHPChanged;
    public Action OnArmorChanged;
    //public Action OnPlayerDeath;

    [SerializeField] private int _hp;

    public int Hp { get => _hp;
        set
        { 
            if(Armor > 0 )
            {
                _hp = (int)(value * 0.85f);
                Armor -= (int)(_armor * 0.1f); 
            }
            if (_hp < 0)
            {
                SimulateDeath();
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

    public enum Unit
    {
        Terrorist,
        CounterTerrorist
    }

    [SerializeField] private Unit _teamUnit;
    public Unit TeamUnit { get => _teamUnit; }

    private void SimulateDeath()
    {
        if (TeamUnit == Unit.CounterTerrorist)
        {
            GameManager.Instance.UpdateKillCounter(false, true);
        }
        else
        {
            GameManager.Instance.UpdateKillCounter(true, false);
        }
        RespawnManager.Instance.RespawnHuman(this, CompareTag("Player"));
        PlayerList.Instance.RemovePlayer(this);
        Destroy(gameObject);
    }
}
