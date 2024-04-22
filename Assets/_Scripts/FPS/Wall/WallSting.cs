using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : ����
/// ���ú� Ŭ����
/// </summary>
public class WallSting : Wall
{
    [SerializeField] LayerMask checkPlayer;
    [SerializeField] float damage;

    // �浹üũ

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�浹");
        if (checkPlayer.Contain(collision.gameObject.layer))
        {
            Debug.Log("���̾�üũ");
            FPSPiece target;
            collision.gameObject.TryGetComponent<FPSPiece>(out target);

            target?.TakeDamage(damage);
        }
    }

    // �浹�� ���� �÷��̾��� ��� ���� ���ݷ¸�ŭ �÷��̾�� ������
}
