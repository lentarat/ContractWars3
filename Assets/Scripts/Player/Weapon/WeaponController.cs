using UnityEngine;
using Helpers;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public Weapon CurrentWeapon;

    [SerializeField] private Transform _cameraTransform;
    public Transform CameraTransform { get => _cameraTransform; }
    
    [SerializeField] private GameObject _shootButton;
    [SerializeField] private GameObject _trowGrenadeButton;

    private int _humanLayer;
    private float _lastTimeShot;

    private void Awake()
    {
        _humanLayer = LayerMask.NameToLayer("Human");
    }

    public void Shoot()
    {
        if (CurrentWeapon.BulletsInMagazine <= 0 && CurrentWeapon.BulletsLeft <= 0) return;

        _lastTimeShot = Time.time;

        //if (Time.time > _lastTimeShot + 1f / CurrentWeapon.FireRate)
        //{
            _lastTimeShot = Time.time;
            if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit))
            {

                //need profiler
                if (hit.collider.gameObject.layer == _humanLayer)
                {
                    if (hit.collider.gameObject.TryGetComponent<HumanStats>(out HumanStats humanStats))
                    {
                        humanStats.Hp -= CurrentWeapon.Damage;
                        Debug.Log(humanStats.Hp + "   " + CurrentWeapon.Damage);
                    }
                }
            }

            CurrentWeapon.ShootSFX.Play();
            SubtractABullet();
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_cameraTransform.position, _cameraTransform.forward);
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
            Debug.Log("Hasn't got ammo");
            return false;
        }
        else
        {
            Debug.Log("Has got ammo");
            return true;
        }
    } 

    private void NotifyBulletsAmountChange()
    {
        EventAggregator.Post(this, CurrentWeapon);
    }
}
