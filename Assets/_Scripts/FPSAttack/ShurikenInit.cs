using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// �簡 ����� ������ Ŭ����
/// </summary>
public class ShurikenInit : ChargingWeapon
{
    [SerializeField] Bullet shuriken;
    protected override void Shoot(float chargingPower)
    {
        PooledObject PO = Manager.Pool.GetPool(shuriken, transform.position, transform.rotation);
        Bullet initBullet = PO.GetComponent<Bullet>();

        initBullet.Damage = Damage;
        initBullet.Weapon = GetComponent<Weapon>();
        PO.GetComponent<Shuriken>()?.Shoot(transform.forward);
    }
}
