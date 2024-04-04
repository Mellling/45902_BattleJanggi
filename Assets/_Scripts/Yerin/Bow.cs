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
    // ��¡
    // ������ŭ ���ư��� �Ÿ� �ٸ���

    [SerializeField] float normalPower;
    [SerializeField] Bullet arrow;

    float chargingPower;

    Coroutine chargingCoroutine;

    private void Start()
    {
        chargingPower = 0;
    }

    IEnumerator ChargingPower()
    {
        while (true)
        {
            chargingPower += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Shoot(float chargingPower)
    {
        PooledObject PO = Manager.Pool.GetPool(arrow, transform.position, transform.rotation);
        Bullet initBullet = PO.GetComponent<Bullet>();

        initBullet.Damage = Damage;
        initBullet.Weapon = GetComponent<Weapon>();
        PO.GetComponent<Arrow>()?.Shoot(transform.forward);
    }

    public override void Charging()
    {
        chargingCoroutine = StartCoroutine(ChargingPower());
    }

    public override void Fire()
    {
        StopCoroutine(chargingCoroutine);
        Shoot(chargingPower);
        chargingPower = 0;
    }

    public float BowPower()
    {
        return chargingPower + normalPower;
    }
}
