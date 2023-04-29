using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseUnit : MonoBehaviour
{
    [SerializeField] private Button _ctUnit;
    [SerializeField] private Button _tUnit;

    public System.Action<Unit> OnUnitChosen;

    public enum Unit
    {
        Ct,
        T
    }

    private void Awake()
    {
        _ctUnit.onClick.AddListener(() => SetChosenUnit(Unit.Ct));
        _tUnit.onClick.AddListener(() => SetChosenUnit(Unit.T));
    }

    private void SetChosenUnit(Unit unit)
    {
        OnUnitChosen?.Invoke(unit);
        gameObject.SetActive(false);
    }
}



//public class ChooseUnit : MonoBehaviour
//{
//    [SerializeField] private Button _ctUnit;
//    [SerializeField] private Button _tUnit;

//    public System.Action<object, Unit> OnUnitChosen;

//    public enum Unit
//    {
//        Ct,
//        T
//    }

//    private void Awake()
//    {
//        _ctUnit.onClick.AddListener(() => SetChosenUnit(Unit.Ct));
//        _tUnit.onClick.AddListener(() => SetChosenUnit(Unit.T));
//    }

//    private void SetChosenUnit(Unit unit)
//    {
//        OnUnitChosen?.Invoke(this, unit);
//    }
//}
