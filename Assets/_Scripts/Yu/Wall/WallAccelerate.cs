using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ : Changyu
/// ��� ��(��)�� �� ����.
/// ���Խ� �÷��̾�� ������ �ִ� �������� ����
/// </summary>
public class WallAccelerate : Wall
{
    [SerializeField] LayerMask checkPlayer;

    float baseSpeed = 10f;

    // TriggerEnter�� ����üũ�ϰ�
    private void OnTriggerEnter(Collider other)
    {
        if (checkPlayer.Contain(other.gameObject.layer))
        {
            other.gameObject.GetComponent<FPSPiece>().MoveSpeed += baseSpeed * 0.05f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (checkPlayer.Contain(other.gameObject.layer))
        {
            other.gameObject.GetComponent<FPSPiece>().MoveSpeed -= baseSpeed * 0.05f;
        }
    }
}
