using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// ��(��)���� ������ ȭ�� ���� Ŭ����
/// </summary>
public class WallArrow : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] LayerMask playerCheck;

    private void OnCollisionEnter(Collision collision)
    {
        if (playerCheck.Contain(collision.gameObject.layer))
        {
            FPSPiece target;
            collision.gameObject.TryGetComponent<FPSPiece>(out target);

            target?.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
