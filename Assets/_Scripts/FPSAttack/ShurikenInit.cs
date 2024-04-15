using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ������: Yerin
/// 
/// �簡 ����� ������ Ŭ����
/// </summary>
public class ShurikenInit : ChargingWeapon
{
    [SerializeField] Bullet shuriken;

    float rate = 1f;     // ����ӵ�
    bool isfire;

    protected override void Start()
    {
        base.Start();
        isfire = true;
    }

    void OnReload(InputValue value)
    {
        StartCoroutine(Reload());
    }

    protected override void Shoot(float chargingPower)
    {
        if (curMagazine > 0)
        {
            if (!isfire)
                return;

            PooledObject PO = Manager.Pool.GetPool(shuriken, transform.position, transform.rotation);
            Bullet initBullet = PO.GetComponent<Bullet>();

            curMagazine--;

            initBullet.Damage = Damage;
            initBullet.Weapon = GetComponent<Weapon>();
            PO.GetComponent<Shuriken>()?.Shoot(transform.forward);
            StartCoroutine(CalRate());
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator CalRate()
    {
        isfire = false;
        yield return new WaitForSeconds(rate);
        isfire = true;
    }

    IEnumerator Reload()
    {
        isfire = false;
        yield return new WaitForSeconds(1f);
        isfire = true;
        curMagazine = maxMagazine;
    }
}
