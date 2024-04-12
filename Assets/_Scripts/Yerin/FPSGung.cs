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
    [SerializeField] GameObject shield;

    [SerializeField] int existSa;           // �����ִ� ���� ������ŭ �ǰݹ��� �� ����

    public int ExistSa { get { return existSa; } set { existSa = value; if (existSa == 0) shield.SetActive(false); } }

    Coroutine skill;

    private void Start()
    {
        WallSa[] cats = FindObjectsOfType<WallSa>();
        if (cats != null && cats.Length > 0)
        {
            ExistSa = cats.Length;
        }
        else
        {
            ExistSa = 0;
        }
    }

    public override void TakeDamage(float damage)
    {
        if (ExistSa > 0)
        {
            ExistSa--;
        }
        else
        {
            base.TakeDamage(damage);
        }
    }

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
