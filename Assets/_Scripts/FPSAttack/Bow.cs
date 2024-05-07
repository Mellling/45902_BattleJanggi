using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ������: Yerin
/// 
/// ���� ����� Ȱ Ŭ����
/// </summary>
public class Bow : ChargingWeapon
{
    [SerializeField] Bullet arrow;

    float rate = 1.5f;     // ����ӵ�
    bool isfire;

    protected override void Start()
    {
        base.Start();
        isfire = true;
    }

    protected override void Shoot(float chargingPower)
    {
        if (isfire)
        {
            PooledObject PO = Manager.Pool.GetPool(arrow, transform.position, transform.rotation);
            Bullet initBullet = PO.GetComponent<Bullet>();

            initBullet.Damage = Damage;
            initBullet.Weapon = GetComponent<Weapon>();
            PO.GetComponent<Arrow>()?.Shoot(transform.forward);
            StartCoroutine(CalRate());
        }
    }

    IEnumerator CalRate()
    {
        isfire = false;
        yield return new WaitForSeconds(rate);
        isfire = true;
    }
}
