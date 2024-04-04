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

    private void Shot(float chargingPower)
    {
        Instantiate(arrow, transform.position, transform.rotation);
    }

    public override void Charging()
    {
        chargingCoroutine = StartCoroutine(ChargingPower());
    }

    public override void Fire()
    {
        StopCoroutine(chargingCoroutine);

        Shot(chargingPower);
    }
}
