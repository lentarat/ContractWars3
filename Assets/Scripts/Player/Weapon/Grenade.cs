using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private GameObject _grenadePrefab;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private Transform _positionToTrow;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _UpwardForce;
    [SerializeField] private float _explosionSpeed;
    public float delay = 3f;
    public float radius = 20f;

   // private bool _enabledToTrow = true;
    [SerializeField] private Camera _cam ;
    // Start is called before the first frame update

    public void StartThrowGrenade()
    {
        if (_weaponController.CurrentWeapon.BulletsInMagazine <= 0 && _weaponController.CurrentWeapon.BulletsLeft <= 0) return;
        _weaponController.SubtractABullet();
        StartCoroutine(GrenedeHendle());
        
    }

    public IEnumerator GrenedeHendle()
    {
        
        GameObject projectile = Instantiate(_grenadePrefab, _positionToTrow.transform.position, _positionToTrow.transform.rotation);
        
        Rigidbody projecrileRB = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = _cam.transform.forward * _explosionForce + gameObject.transform.up * _UpwardForce;

        projecrileRB.AddForce(forceToAdd, ForceMode.Impulse);
        yield return new WaitForSeconds(delay);
        GameObject explotion = Instantiate(_explosionPrefab, projectile.transform.position, projectile.transform.rotation);
        Destroy(projectile.gameObject);
        var players= FindPlayers.GetPlayersInRadius(projectile.transform.position,radius);

        //Debug.Log(players.Length);
        foreach (var player in players)
        {
            player.Hp += (int)(_weaponController.CurrentWeapon.Damage / Vector3.Distance(player.transform.position, projectile.transform.position)  < 1 ? 1 : Vector3.Distance(player.transform.position, projectile.transform.position));
            //Debug.Log(player.Hp);
        }

        
        yield return new WaitForSeconds(delay);
        Destroy(explotion);
        
    }

}
