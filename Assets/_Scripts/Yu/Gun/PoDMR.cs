using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// ������ : ChanGyu
/// ��⸻(��)�� DMR(�����������)
/// </summary>
public class PoDMR : Gun
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ParticleSystem muzzleFlash;

    float rate = 2f;        // �߻簣��

    bool checkFirable;
    bool isReloading;

    protected override void Start()
    {
        base.Start();
        checkFirable = true;
        isReloading = false;
    }

    void OnReload(InputValue value)
    {
        StartCoroutine(Reload());
    }

    public override void Fire()
    {
        if (curMagazine > 0)
        {
            if (!checkFirable)
                return;

            muzzleFlash.Play();
            PooledObject PO = Manager.Pool.GetPool(Bullet, muzzlePoint.position, muzzlePoint.rotation);
            Bullet initBullet = PO.GetComponent<Bullet>();

            curMagazine--;

            initBullet.Damage = Damage;
            initBullet.Weapon = GetComponent<Weapon>();
            StartCoroutine(FireChecker());
        }
        else
        {
            isReloading = true;

            if (isReloading)
                return;

            StartCoroutine(Reload());
        }
    }

    IEnumerator FireChecker()
    {
        checkFirable = false;
        yield return new WaitForSeconds(rate);
        checkFirable = true;
    }

    IEnumerator Reload()
    {
        checkFirable = false;
        yield return new WaitForSeconds(1f);
        checkFirable = true;
        isReloading = false;
        curMagazine = maxMagazine;
    }
}
