using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ : ChanGyu
/// �������� ��ź�� ������ ����Ʈ
/// </summary>
public class LazerGunImpact : Impact
{
    private void OnEnable()
    {
        StartCoroutine(SetOff());
    }

    IEnumerator SetOff()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
