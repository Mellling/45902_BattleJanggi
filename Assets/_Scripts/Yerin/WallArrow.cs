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
    private void OnCollisionEnter(Collision collision)
    {
        FPSPiece target;
        collision.gameObject.TryGetComponent<FPSPiece>(out target);

        target?.TakeDamage(damage);

        gameObject.SetActive(false);
    }
}
