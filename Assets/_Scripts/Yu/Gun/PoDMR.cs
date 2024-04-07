using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ : ChanGyu
/// ��⸻(��)�� DMR(�����������)
/// </summary>
public class PoDMR : Gun
{
    [SerializeField] Transform muzzlePoint;
    [SerializeField] ParticleSystem muzzleFlash;

    [SerializeField] float rate;        // �߻簣��

    bool checkFirable;

    private void Start()
    {
        checkFirable = true;
    }

    public override void Fire()
    {
        if (!checkFirable)
            return;

        muzzleFlash.Play();
        PooledObject PO = Manager.Pool.GetPool(Bullet, muzzlePoint.position, muzzlePoint.rotation);
        Bullet initBullet = PO.GetComponent<Bullet>();

        initBullet.Damage = Damage;
        initBullet.Weapon = GetComponent<Weapon>();
        StartCoroutine(FireChecker());
    }

    IEnumerator FireChecker()
    {
        checkFirable = false;
        yield return new WaitForSeconds(rate);
        checkFirable = true;
    }
}
