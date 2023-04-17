using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //[SerializeField] private WeaponChange _currentWeapon;
    [SerializeField] private BulletsManager _bulletsManager;

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
            if (Time.time > _timeWhenStoppedShooting + _bulletsManager.CurrentWeapon.PeriodBetweenShots)
            {

                _bulletsManager.SubtractABullet();
                _timeWhenStoppedShooting = Time.time;
            }
            yield return null;
        }
    }
    //private IEnumerator Shoot()
    //{
    //    while (true)
    //    {
    //        Debug.Log(Time.time);
    //        _bulletsManager.SubtractABullet();
    //            _timeWhenStoppedShooting = Time.time;
            
    //        yield return new WaitForSeconds(_bulletsManager.CurrentWeapon.PeriodBetweenShots);
    //    }
    //}
}
