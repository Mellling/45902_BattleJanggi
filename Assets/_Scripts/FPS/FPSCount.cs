using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : ����
/// FPS���۽� ����Ͽ��� ���ư��� ī��Ʈ�� �����
/// </summary>
public class FPSCount : MonoBehaviour
{
    private void Start()
    {
        Manager.JanggiTurn.StopTurnCount();
    }
}
