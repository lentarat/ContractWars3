using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private WeaponController _weaponController;

    private IEnumerator _shootCoroutine;
    private float _timeWhenStoppedShooting;

    private void Awake()
    {
        _shootCoroutine = Shoot();
    }



    public void OnPointerDown(PointerEventData pointerEventData)
    {
        StartCoroutine(_shootCoroutine);

    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        StopCoroutine(_shootCoroutine);
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (Time.time > _timeWhenStoppedShooting + 1f / _weaponController.CurrentWeapon.FireRate)
            {
                _weaponController.SubtractABullet();
                _timeWhenStoppedShooting = Time.time;
            }
            yield return null;
        }
    }
}
