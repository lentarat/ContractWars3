using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DisplayStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _armorText;
    [SerializeField] private HumanStats _player;

    private void Awake()
    {
        _player.OnHPChanged += ChangeHP;
        _player.OnArmorChanged += ChangeArmor;
    }

    // OnHPChanged vs ChangeHP 
    private void ChangeHP()
    {
        Debug.Log(_player.Hp);
        _healthText.text = _player.Hp.ToString();
    }

    private void ChangeArmor()
    {
        _armorText.text = _player.Armor.ToString();
    }

}
