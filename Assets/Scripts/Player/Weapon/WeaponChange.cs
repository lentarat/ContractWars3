using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;

    [SerializeField] private Image _inventoryImage;

    [SerializeField] private Button _currentWeaponButton;
    [SerializeField] private Button _mainButton;
    [SerializeField] private Button _secondaryButton;

    [SerializeField] private WeaponHolder _currentWeaponHolder;
    public WeaponHolder CurrentWeaponHolder { get => _currentWeaponHolder; }
    [SerializeField] private WeaponHolder _mainWeaponHolder;
    public WeaponHolder MainWeaponHolder { get => _mainWeaponHolder; }
    [SerializeField] private WeaponHolder _secondaryWeaponHolder;
    public WeaponHolder SecondaryWeaponHolder { get => _secondaryWeaponHolder; }
    [SerializeField] private WeaponHolder _previousWeaponHolder;
    public WeaponHolder PreviousWeaponHolder { get => _previousWeaponHolder; }

    private void Awake()
    {
        _mainButton.onClick.AddListener(()=>SetCurrentWeaponFromInventory(_mainWeaponHolder));
        _secondaryButton.onClick.AddListener(()=>SetCurrentWeaponFromInventory(_secondaryWeaponHolder));

        //_currentWeaponHolder.ImageInSlot.color = _mainWeaponHolder.ImageInSlot.color; // _currentWeaponHolder or CurrentWeaponHolder?
        //_currentWeaponHolder.WeaponInSlot = _mainWeaponHolder.WeaponInSlot;
    }
    public void SetCurrentWeaponFromInventory(WeaponHolder chosenWeaponHolder)
    {
        if (chosenWeaponHolder.WeaponInSlot == _currentWeaponHolder.WeaponInSlot)
        {
            SetInventoryActive(false);
            return;
        }

        Weapon tempWeapon = chosenWeaponHolder.WeaponInSlot;
        Vector4 tempColor = chosenWeaponHolder.ImageInSlot.color;

        _previousWeaponHolder.ImageInSlot.color = _currentWeaponHolder.ImageInSlot.color;
        _previousWeaponHolder.WeaponInSlot = _currentWeaponHolder.WeaponInSlot;

        _currentWeaponHolder.ImageInSlot.color = tempColor;
        _currentWeaponHolder.WeaponInSlot = tempWeapon; 

        _weaponController.SetCurrentWeapon(_currentWeaponHolder.WeaponInSlot);
        SetInventoryActive(false);
    }

    public void SetInventoryActive(bool state)
    {
        _inventoryImage.gameObject.SetActive(state);
    }

    public bool GetInventoryState()
    {
        return _inventoryImage.gameObject.activeSelf;
    }
}
