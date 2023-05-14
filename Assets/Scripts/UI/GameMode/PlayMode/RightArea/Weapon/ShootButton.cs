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
            _weaponController.Shoot();
            yield return null;
        }
    }
}
