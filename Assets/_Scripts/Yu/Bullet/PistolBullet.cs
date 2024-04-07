using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ : ChanGyu
/// ��⸻(��)�� ��� ���ѿ��� ������ �Ѿ�
/// </summary>
public class PistolBullet : Bullet
{
    [SerializeField] PistolImpact explodeEffect;        // źȯ�� ����� �� ������ ����Ʈ

    protected override void OnEnable()
    {
        base.OnEnable();
        Rigid.velocity = transform.forward * Speed;
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        FPSPiece target;
        collision.gameObject.TryGetComponent<FPSPiece>(out target);

        target?.TakeDamage(Damage);
        Manager.Pool.GetPool(explodeEffect, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Rigid.velocity = Vector3.zero;
    }
}
