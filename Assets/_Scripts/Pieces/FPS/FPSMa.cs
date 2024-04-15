using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ������: Yerin
/// 
/// ��⸻(��) ���� Ŭ���� 
/// ��⸻�� ����� �θ� Ŭ������, ���� ���� ��ų
/// </summary>
public class FPSMa : FPSPiece
{
    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(7f);

        MoveSpeed = MoveSpeed / 1.3f;
        CanUseSkill = true;
    }

    protected override void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            MoveSpeed = MoveSpeed * 1.3f;

            skill = StartCoroutine(Skill());

            CanUseSkill = false;

            CoolTime(30f);
            base.OnSkill(value);
        }
    }
}
