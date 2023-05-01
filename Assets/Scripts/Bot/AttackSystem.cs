using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem
{
    public WeaponController WeaponController { get; private set; }
    public Transform Body { get; private set; }
    public Transform Camera { get; private set; }

    public AttackSystem(WeaponController weaponController, Transform body, Transform camera)
    {
        WeaponController = weaponController;
        Body = body;
        Camera = camera;
    }

    public void Attack(HumanStats currentSpottedEnemy)
    {
        Body.LookAt(currentSpottedEnemy.transform);
        WeaponController.Shoot();
    }

    //private void FaceTarget(Vector3 destination)
    //{
    //    Vector3 lookPos = destination - Body.position;
    //    lookPos.y = 0;
    //    Quaternion rotation = Quaternion.LookRotation(lookPos);
    //    Body.rotation = Quaternion.Slerp(Body.rotation, rotation,);
    //}
}
