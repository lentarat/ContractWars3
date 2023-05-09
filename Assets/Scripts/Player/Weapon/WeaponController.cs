using UnityEngine;
using Helpers;

public class WeaponController : MonoBehaviour
{
    [SerializeField] public Weapon CurrentWeapon;

    [SerializeField] private Transform _cameraTransform;
    public Transform CameraTransform { get => _cameraTransform; }
    [SerializeField] private Vector3 _headOffset;
    
    [SerializeField] private GameObject _shootButton;
    [SerializeField] private GameObject _throwGrenadeButton;

    private float _lastTimeShot;
    private bool _isPlayer;
    //private HumanStats.Unit _teamUnit; // team killing

    private void Start()
    {
        _isPlayer = gameObject.CompareTag("Player");
        //_teamUnit = gameObject.GetComponent<HumanStats>().TeamUnit;
    }

    public void Shoot()
    {
        if (CurrentWeapon.BulletsInMagazine <= 0 && CurrentWeapon.BulletsLeft <= 0) return;

        if (Time.time > _lastTimeShot + 1f / CurrentWeapon.FireRate)
        {
            _lastTimeShot = Time.time;
            if (Physics.Raycast(transform.position + _headOffset, transform.forward, out RaycastHit hit))
            {
                //need profiler
                if (hit.collider.gameObject.TryGetComponent<HumanStats>(out HumanStats humanStats))
                {
                    //if (humanStats.TeamUnit != _teamUnit) // disable team killing
                    //{
                    //    humanStats.Hp -= CurrentWeapon.Damage; 
                    //}
                    humanStats.Hp -= CurrentWeapon.Damage;
                }
            }

            CurrentWeapon.ShootSFX.Play();
            SubtractABullet();
        }
    }

    public void SetCurrentWeapon(Weapon chosenWeaponFromInventory)
    {
        CurrentWeapon = chosenWeaponFromInventory;

        if (CurrentWeapon.WeaponTypes  == Weapon.WeaponType.Grenade)
        {
            _shootButton.SetActive(false);
            _throwGrenadeButton.SetActive(true);
        }
        else
        {
            _shootButton.SetActive(true);
            _throwGrenadeButton.SetActive(false);
        }
        //
        
        NotifyBulletsAmountChange();
    }

    public void SubtractABullet()
    {
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
            return false;
        }
        else
        {
            return true;
        }
    }

    private void NotifyBulletsAmountChange()
    {
        if (_isPlayer)
        {
            EventAggregator.Post(this, CurrentWeapon);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + _headOffset, transform.forward);
    }
}
