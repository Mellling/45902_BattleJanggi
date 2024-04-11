using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// ������ : ChanGyu
/// ��⸻ (��)�� �⺻����
/// </summary>
public class ZolPistol : Gun
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] int maxMagazine;       // źâ�� �� ���ִ� ��� źȯ�� ��
    [SerializeField] int curMagazine;       // ���� źâ�� źȯ ��

    float rate = 0.75f;     // ����ӵ�
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

    public override void Fire()
    {
        if (curMagazine > 0)
        {
            if (isfire)
            {
                muzzleFlash.Play();
                PooledObject PO = Manager.Pool.GetPool(Bullet, muzzlePoint.position, muzzlePoint.rotation);
                Bullet initBullet = PO.GetComponent<Bullet>();

                curMagazine--;

                initBullet.Damage = Damage;
                initBullet.Weapon = GetComponent<Weapon>();
                StartCoroutine(CalRate());
            }
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
