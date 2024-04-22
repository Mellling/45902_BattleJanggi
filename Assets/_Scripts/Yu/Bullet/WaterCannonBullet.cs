using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ : ChanGyu
/// ���������� ������ źȯ
/// </summary>
public class WaterCannonBullet : Bullet
{
    [SerializeField] WaterCannonImpact explodeEffect;        // źȯ�� ����� �� ������ ����Ʈ
    float id;

    protected override void OnEnable()
    {
        base.OnEnable();
        Rigid.velocity = transform.forward * Speed;
    }

    //private void FixedUpdate()
    //{
    //    Vector3 nextPos = transform.position + Rigid.velocity * Time.fixedDeltaTime;
    //    if (Physics.Linecast(transform.position, nextPos, out RaycastHit hitInfo))
    //    {
    //        FPSPiece target;
    //        hitInfo.collider.gameObject.TryGetComponent<FPSPiece>(out target);

    //        target?.TakeDamage(Damage);

    //        Manager.Pool.GetPool(explodeEffect, transform.position, Quaternion.LookRotation(hitInfo.normal));

    //        gameObject.SetActive(false);
    //    }
    //}

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
