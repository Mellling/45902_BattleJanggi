using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : ChanGyu
/// ���Ʈ������ źȯ
/// </summary>
public class ARBullet : Bullet
{
    [SerializeField] ARImpact explodeEffect;        // źȯ�� ����� �� ������ ����Ʈ
    /// <summary>
    /// źȯ�� Ǯ������ �� źȯ�� ������ �ӵ��� �����ش�
    /// </summary>
    protected override void OnEnable()
    {
        base.OnEnable();
        Rigid.velocity = transform.forward * Speed;
    }
    /// <summary>
    /// źȯ�� �ǰ�����
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 nextPos = transform.position + Rigid.velocity * Time.fixedDeltaTime;
        if (Physics.Linecast(transform.position, nextPos, out RaycastHit hitInfo))
        {
            FPSPiece target;
            hitInfo.collider.gameObject.TryGetComponent<FPSPiece>(out target);

            target?.TakeDamage(Damage);

            Manager.Pool.GetPool(explodeEffect, transform.position, Quaternion.LookRotation(hitInfo.normal));

            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Rigid.velocity = Vector3.zero;
    }
}
