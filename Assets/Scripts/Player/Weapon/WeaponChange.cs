using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] private Image _inventoryImage;

    [SerializeField] private Button _currentWeaponButton;

    [SerializeField] private Button _mainButton;
    [SerializeField] private Button _secondaryButton;
    [SerializeField] private Button _meleeButton;
    [SerializeField] private Button _grenadeButton;

    public System.Action OnCurrentWeaponChange;

    private Image _currentWeaponImage;
    private Image _mainWeaponImage;
    private Image _secondaryWeaponImage;
    private Image _meleeWeaponImage;
    private Image _grenadeWeaponImage;
    private InventoryWeaponHolder _currentInventoryHolder;
    private InventoryWeaponHolder _mainInventoryHolder;
    private InventoryWeaponHolder _secondaryInventoryHolder;
    private InventoryWeaponHolder _meleeInventoryHolder;
    private InventoryWeaponHolder _grenadeInventoryHolder;

    private void Awake()
    {
        _currentWeaponImage = _currentWeaponButton.GetComponent<Image>();
        _mainWeaponImage = _mainButton.GetComponent<Image>();
        _secondaryWeaponImage = _secondaryButton.GetComponent<Image>();

        _currentInventoryHolder = _currentWeaponImage.GetComponent<InventoryWeaponHolder>();
        _mainInventoryHolder = _mainButton.GetComponent<InventoryWeaponHolder>();
        _secondaryInventoryHolder = _secondaryButton.GetComponent<InventoryWeaponHolder>();

        _mainButton.onClick.AddListener(()=>SetCurrentWeaponFromInventory(_mainWeaponImage, _mainInventoryHolder));
        _secondaryButton.onClick.AddListener(()=>SetCurrentWeaponFromInventory(_secondaryWeaponImage, _secondaryInventoryHolder));

        SetCurrentWeaponFromInventory(_mainWeaponImage, _mainInventoryHolder);
    }

    private void SetCurrentWeaponFromInventory(Image chosenWeaponImage, InventoryWeaponHolder inventoryWeaponHolder)
    {
        _currentWeaponImage.color = chosenWeaponImage.color;
        _currentInventoryHolder.CurrentWeaponInSlot = inventoryWeaponHolder.CurrentWeaponInSlot;
        OnCurrentWeaponChange?.Invoke();   
    }

    private void SetInventoryActive(bool state)
    {
        _inventoryImage.gameObject.SetActive(state);
    }

}
