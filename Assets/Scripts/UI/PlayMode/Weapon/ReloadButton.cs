using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponManager;

    [SerializeField] private Button _reloadButton;

    private void Awake()
    {
        _reloadButton.onClick.AddListener(Reload);
    }

    private void Reload()
    {
        _weaponManager.Reload();
    }
}
