using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Helpers;
using Helpers.Events;

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
        _bulletShowerText.text = eventData.Bullets.ToString();
    }
}
