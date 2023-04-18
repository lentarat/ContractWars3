using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using Helpers.Events;
public class WeaponManager : MonoBehaviour
{
    [SerializeField] public Weapon CurrentWeapon;

    private void Awake()
    {
        
    }

    public void Reload()
    {
        if (CurrentWeapon.BulletsInMagazine == CurrentWeapon.MaximumBulletsInMagazine || CurrentWeapon.BulletsLeft == 0) return;
        Debug.Log("Reloading...");
        if (CurrentWeapon.BulletsLeft < CurrentWeapon.MaximumBulletsInMagazine - CurrentWeapon.BulletsInMagazine)
        {
            CurrentWeapon.BulletsInMagazine += CurrentWeapon.BulletsLeft;
            CurrentWeapon.BulletsLeft = 0;
        }
        else
        {
            CurrentWeapon.BulletsLeft -= CurrentWeapon.MaximumBulletsInMagazine - CurrentWeapon.BulletsInMagazine;
            CurrentWeapon.BulletsInMagazine = CurrentWeapon.MaximumBulletsInMagazine;
        }
        NotifyBulletAmountChange();
    }

    public void SetCurrentWeapon(Weapon chosenWeaponFromInventory)
    {
        CurrentWeapon = chosenWeaponFromInventory;
        NotifyBulletAmountChange();
    }

    public void SubtractABullet()
    {
        if (CurrentWeapon.BulletsInMagazine <= 0) return;
        CurrentWeapon.BulletsInMagazine--;
        if (CurrentWeapon.BulletsInMagazine == 0)
        {
            Reload();
        }
        NotifyBulletAmountChange();
    }

    public void SetBullets(int bulletsInMagazine, int bulletsLeft)
    {
        
    }

    private void NotifyBulletAmountChange()
    {
        EventAggregator.Post(this, CurrentWeapon);
    }
}
