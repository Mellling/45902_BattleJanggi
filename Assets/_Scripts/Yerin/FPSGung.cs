using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ������: Yerin
/// 
/// ��⸻(��) ���� Ŭ���� 
/// ��⸻�� ����� �θ� Ŭ������, ���� ���� ��ų
/// </summary>
public class FPSGung : FPSPiece
{
    [SerializeField] GungSkill gungSkill;

    Coroutine skill;

    IEnumerator Skill()
    {
        gungSkill.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        CanUseSkill = true;
        gungSkill.gameObject.SetActive(false);
    }

    private void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            skill = StartCoroutine(Skill());
        }
    }
}
