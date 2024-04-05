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
    [SerializeField] ParticleSystem muzzleFlash;

    [SerializeField] float rate;        // ����ӵ�

    Coroutine coroutine;

    public override void Fire()
    {
        muzzleFlash.Play();
        PooledObject PO = Manager.Pool.GetPool(Bullet, muzzlePoint.position, muzzlePoint.rotation);
        Bullet initBullet = PO.GetComponent<Bullet>();

        initBullet.Damage = Damage;
        initBullet.Weapon = GetComponent<Weapon>();
    }

    /// <summary>
    /// ����ӵ��� üũ�ؼ� ��� ���
    /// </summary>
    /// <returns></returns>
    IEnumerator Firing()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(rate);
        }
    }

    public void StartFiring()
    {
        coroutine = StartCoroutine(Firing());
    }

    public void StopFiring()
    {
        StopCoroutine(coroutine);
    }
}
