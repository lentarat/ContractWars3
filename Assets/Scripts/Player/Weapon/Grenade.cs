using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private GameObject _grenadePrefab;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private Transform _positionToTrow;
    [SerializeField] private float _forwardForce;
    [SerializeField] private float _upwardForce;
    private float _delay = 3f;
    private float _radius = 20f;

   // private bool _enabledToTrow = true;
    [SerializeField] private Camera _cam ;
    // Start is called before the first frame update

    public void StartThrowGrenade()
    {
        if (_weaponController.CurrentWeapon.BulletsInMagazine <= 0 && _weaponController.CurrentWeapon.BulletsLeft <= 0) return;
        _weaponController.SubtractABullet();
        StartCoroutine(GrenadeHandle());
        
    }

    public IEnumerator GrenadeHandle()
    {
        
        GameObject projectile = Instantiate(_grenadePrefab, _positionToTrow.transform.position, _positionToTrow.transform.rotation);
        
        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = _cam.transform.forward * _forwardForce + _positionToTrow.transform.up * _upwardForce;

        projectileRB.AddForce(forceToAdd, ForceMode.Impulse);
        yield return new WaitForSeconds(_delay);
        GameObject explotion = Instantiate(_explosionPrefab, projectile.transform.position, projectile.transform.rotation);
        Destroy(projectile.gameObject);
        var players = PlayerList.Instance.GetPlayersInRadius(projectile.transform.position, _radius);
        //var players = PlayerList.Instance.GetPlayersInRadius(projectile.transform.position, _radius);

        //Debug.Log(players.Length);
        foreach (var player in players)
        {
            PlayerList.Instance.ShowPlayerListContext();
            float distanceFromPlayerToExplosion = Vector3.Distance(player.transform.position, projectile.transform.position);
            player.Hp += (int)(_weaponController.CurrentWeapon.Damage /
                distanceFromPlayerToExplosion < 1 ? 1 : distanceFromPlayerToExplosion);
            //Debug.Log(player.Hp);
        }

        
        yield return new WaitForSeconds(_delay);
        Destroy(explotion);
        
    }

}
