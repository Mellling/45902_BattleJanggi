using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : ����
/// FPS���۽� ����Ͽ��� ���ư��� ī��Ʈ�� �����
/// </summary>
public class SetFPS : MonoBehaviour
{
    private void Start()
    {
        Manager.JanggiTurn.StopTurnCount();
        Manager.KillListManager.gameObject.SetActive(false);
    }
}
