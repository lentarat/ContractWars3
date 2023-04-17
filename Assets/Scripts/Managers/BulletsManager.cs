using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using Helpers.Events;
public class BulletsManager : MonoBehaviour
{
    [SerializeField] public Weapon CurrentWeapon;
    public void AddABullet()
    {

    }
    public void AddBullets(int amount)
    {

    }
    public void SubtractABullet()
    {
        CurrentWeapon.Bullets--;
        NotifyBulletAmountChange();
    }
    public void SubtractBullets(int amount)
    {

    }
    private void NotifyBulletAmountChange()
    {
        EventAggregator.Post(this, CurrentWeapon);
    }
}
