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
    [SerializeField] GameObject sword;

    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(3f);

        CanUseSkill = true;
    }

    private void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            
        }
    }
}
