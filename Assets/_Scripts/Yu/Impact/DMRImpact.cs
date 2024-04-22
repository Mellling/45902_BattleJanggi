using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ : ChanGyu
/// DMR ��ź �� ������ ����Ʈ
/// </summary>
public class DMRImpact : Impact
{
    private void OnEnable()
    {
        StartCoroutine(SetOff());
    }

    IEnumerator SetOff()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
