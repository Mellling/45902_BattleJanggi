using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// ���� : ����
/// ��⸻(��)�� ��ų �ߵ� ������Ʈ
/// </summary>
public class FPSCha : FPSPiece
{
    [SerializeField] FPSChaSkill skill;

    protected override void OnSkill(InputValue value)
    {
        skill.OnSkill(value);
        base.OnSkill(value);
    }
}
