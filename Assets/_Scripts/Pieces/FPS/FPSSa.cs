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
public class FPSSa : FPSPiece
{
    [SerializeField] GameObject cat;

    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(3f);

        cat.layer = LayerMask.NameToLayer("Player");
        CanUseSkill = true;
    }

    private void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            cat.layer = LayerMask.NameToLayer("Invisible");
            skill = StartCoroutine(Skill());

            CanUseSkill = false;

            CoolTime(30f);
        }
    }

    protected override void Die()
    {
        // �ѳ����� �簡 �׾��� ���
        Manager.JanggiTurn.HanSa--;
        // �ʳ����� �簡 �׾��� ���
        Manager.JanggiTurn.ChoSa--;

        base.Die();
    }
}
