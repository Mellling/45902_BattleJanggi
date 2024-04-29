using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// ���� : ChanGyu
/// ���Ʈ������ źȯ
/// </summary>
public class ARBullet : Bullet
{
    [SerializeField] ARImpact explodeEffect;        // źȯ�� ����� �� ������ ����Ʈ
    [SerializeField] LayerMask playerCheck;         // �÷��̾� üũ�ϴ� ���̾��ũ

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
        RaycastHit[] hits;

        Vector3 nextPos = transform.position + Rigid.velocity * Time.fixedDeltaTime;
        hits = Physics.RaycastAll(transform.position, transform.forward, Vector3.Distance(transform.position, nextPos));

        foreach (RaycastHit hit in hits)
        {
            if (playerCheck.Contain(hit.transform.gameObject.layer))
            {
                FPSPiece target;
                hit.collider.gameObject.TryGetComponent<FPSPiece>(out target);

                target?.TakeDamage(Damage);

                Manager.Pool.GetPool(explodeEffect, hit.point, Quaternion.LookRotation(hit.normal));

                gameObject.SetActive(false);
                return;
            }

            Collider[] colls = hit.transform.gameObject.GetComponents<Collider>();

            foreach (Collider coll in colls)
            {
                if (coll.isTrigger)
                {
                    break;
                }
                else
                {
                    Manager.Pool.GetPool(explodeEffect, hit.point, Quaternion.LookRotation(hit.normal));

                    gameObject.SetActive(false);

                    return;
                }
            }
        }
    }

    private void OnDisable()
    {
        Rigid.velocity = Vector3.zero;
    }
}
