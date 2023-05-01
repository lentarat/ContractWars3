using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponType _weaponType;
    public WeaponType WeaponTypes { get => _weaponType; }
    [SerializeField] private WeaponModel _weaponModel;

    [SerializeField] private int _damage;
    public int Damage { get => _damage; set => _damage = value; }
    [SerializeField] private float _reloadTime;
    public float ReloadTime { get => _reloadTime; set => _reloadTime = value; }
    [SerializeField] private float _fireRate;
    public float FireRate { get => _fireRate; set => _fireRate = value; }
    [SerializeField] private float _weight;
    public float Weight { get => _weight; set => _weight = value; }
    [SerializeField] private int _bulletsInMagazine;
    public int BulletsInMagazine { get => _bulletsInMagazine;set => _bulletsInMagazine = value; }
    [SerializeField] private int _maximumBulletsInMagazine;
    public int MaximumBulletsInMagazine { get => _maximumBulletsInMagazine; set => _maximumBulletsInMagazine = value; }
    [SerializeField] private int _bulletsLeft;
    public int BulletsLeft { get => _bulletsLeft; set => _bulletsLeft = value; }
    [SerializeField] private AudioSource _shootSFX;
    public AudioSource ShootSFX { get => _shootSFX; set => _shootSFX = value; }
    [SerializeField] private AudioSource _reloadSFX;
    public AudioSource ReloadSFX { get => _reloadSFX; set => _reloadSFX = value; }

     public enum WeaponType
    {
        Main,
        Secondary,
        Melee,
        Grenade
    }
    enum WeaponModel
    {
        Ak_47,
        M4a4,
        Usp,
        Glock,
        Grenade
    }
}
