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
public class FPSSang : FPSPiece
{
    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(5f);

        MoveSpeed = MoveSpeed / 1.3f;
        CanUseSkill = true;
    }

    private void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            MoveSpeed = MoveSpeed * 1.3f;

            skill = StartCoroutine(Skill());

            CanUseSkill = false;

            CoolTime(30f);
        }
    }
}
