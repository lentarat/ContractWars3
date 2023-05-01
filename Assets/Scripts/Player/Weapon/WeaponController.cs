using UnityEngine;
using Helpers;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public Weapon CurrentWeapon;

    [SerializeField] private Transform cameraTransform;
    
    [SerializeField] private GameObject _shootButton;
    [SerializeField] private GameObject _trowGrenadeButton;

    private int _humanLayer;

    private void Awake()
    {
        _humanLayer = LayerMask.NameToLayer("Human");
    }

    public void Shoot()
    {
        if (CurrentWeapon.BulletsInMagazine  <= 0 && CurrentWeapon.BulletsLeft <= 0) return;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit))
        {

            //need profiler
            if (hit.collider.gameObject.layer == _humanLayer)
            { 
                if (hit.collider.gameObject.TryGetComponent<HumanStats>(out HumanStats humanStats))
                {
                    humanStats.Hp -= CurrentWeapon.Damage;
                    Debug.Log(humanStats.Hp + "   " +CurrentWeapon.Damage);
                    // humanStats.Hp -= (int)((float)CurrentWeapon.Damage * 0.85f); 

                }
            
            }
        }

        CurrentWeapon.ShootSFX.Play();
        SubtractABullet();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(cameraTransform.position, cameraTransform.forward);
    }

    public void SetCurrentWeapon(Weapon chosenWeaponFromInventory)
    {
        CurrentWeapon = chosenWeaponFromInventory;

        // bad architecture implementation (((
        if (CurrentWeapon.WeaponTypes == Weapon.WeaponType.Grenade)
        {
            _shootButton.SetActive(false);
            _trowGrenadeButton.SetActive(true);

            Debug.Log("Grenade Choose");
        }
        else
        {
            _shootButton.SetActive(true);
            _trowGrenadeButton.SetActive(false);
        }
        //
        
        NotifyBulletsAmountChange();
    }

    public void SubtractABullet()
    {
        Debug.Log("SubtractingABullet...");
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

    public bool HasAmmo()
    {
        if (CurrentWeapon.BulletsInMagazine + CurrentWeapon.BulletsLeft == 0)
        {
            Debug.Log("Has got ammo");
            return true;
        }
        else
        {
            Debug.Log("Hasn't got ammo");
            return false;
        }
    } 

    private void NotifyBulletsAmountChange()
    {
        EventAggregator.Post(this, CurrentWeapon);
    }
}
