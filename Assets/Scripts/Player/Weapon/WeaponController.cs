using UnityEngine;
using Helpers;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public Weapon CurrentWeapon;

    [SerializeField] private Transform cameraTransform;

    private int _humanLayer;

    private void Awake()
    {
        _humanLayer = LayerMask.NameToLayer("Human");
    }

    public void Shoot()
    {
        if (Physics.Raycast(transform.position, cameraTransform.forward, out RaycastHit hit))
        {
            //need profiler
            if (hit.collider.gameObject.layer == _humanLayer)
            {
                if (hit.collider.gameObject.TryGetComponent<HumanStats>(out HumanStats humanStats))
                {
                    if (humanStats.Armor > 0)
                    {
                        humanStats.Hp -= (int)((float)CurrentWeapon.Damage * 0.85f);
                    }
                    else
                    {
                        humanStats.Hp -= CurrentWeapon.Damage;
                    }
                }
            }
        }

        CurrentWeapon.ShootSFX.Play();
            // 
            //vfx
            //sounds
            //

        SubtractABullet();
    }

    public void SetCurrentWeapon(Weapon chosenWeaponFromInventory)
    {
        CurrentWeapon = chosenWeaponFromInventory;
        NotifyBulletsAmountChange();
    }

    public void SubtractABullet()
    {
        Debug.Log("SubtractingABullet...");
        if (CurrentWeapon.BulletsInMagazine <= 0) return;
        CurrentWeapon.BulletsInMagazine--;
        if (CurrentWeapon.BulletsInMagazine == 0)
        {
            Reload();
        }
        NotifyBulletsAmountChange();
    }
    public void Reload()
    {
        if (CurrentWeapon.BulletsInMagazine == CurrentWeapon.MaximumBulletsInMagazine || CurrentWeapon.BulletsLeft == 0) return;

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
        NotifyBulletsAmountChange();
    }

    private void NotifyBulletsAmountChange()
    {
        EventAggregator.Post(this, CurrentWeapon);
    }




}
