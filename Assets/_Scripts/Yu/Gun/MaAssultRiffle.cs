using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ : Changyu
/// ��⸻ (��)�� ����
/// </summary>
public class MaAssultRiffle : Gun
{
    [SerializeField] Transform muzzlePoint;

    public override void Fire()
    {
        PooledObject PO = Manager.Pool.GetPool(Bullet, muzzlePoint.position, muzzlePoint.rotation);
        Bullet initBullet = PO.GetComponent<Bullet>();

        initBullet.Damage = Damage;
        initBullet.Weapon = GetComponent<Weapon>();
    }
}
