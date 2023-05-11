using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Helpers;

public class BulletsShower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bulletShowerText;
    private void Awake()
    {
        EventAggregator.Subscribe<Weapon>(BulletAmountChangeHandler);
    }
    private void OnDestroy()
    {
        EventAggregator.Unsubscribe<Weapon>(BulletAmountChangeHandler);
    }
    private void BulletAmountChangeHandler(object sender, Weapon eventData)
    {
        _bulletShowerText.text = string.Concat(eventData.BulletsInMagazine.ToString(), "/", eventData.BulletsLeft.ToString());
    }
}
