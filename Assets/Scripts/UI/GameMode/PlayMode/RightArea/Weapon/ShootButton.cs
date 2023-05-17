using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private WeaponController _weaponController;

    private IEnumerator _shootCoroutine;
    private float _timeWhenStoppedShooting;
    private GameObject muzzle;

    private void Awake()
    {
        _shootCoroutine = Shoot();
        //_weaponController.CurrentWeapon.ShootVFX.gameObject.transform.position = _weaponController.CurrentWeapon.PositionToMuzzle.transform.position;
        //_weaponController.CurrentWeapon.ShootVFX.gameObject.transform.rotation = _weaponController.CurrentWeapon.PositionToMuzzle.transform.rotation;

    }



    public void OnPointerDown(PointerEventData pointerEventData)
    {
        StartCoroutine(_shootCoroutine);
        _weaponController.CurrentWeapon.ShootVFX.gameObject.SetActive(true);
        
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        StopCoroutine(_shootCoroutine);
        
        _weaponController.CurrentWeapon.ShootVFX.gameObject.SetActive(false);


    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            _weaponController.Shoot();

            yield return null;
        }
    }
}
