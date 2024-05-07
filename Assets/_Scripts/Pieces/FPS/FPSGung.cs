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

    [SerializeField] bool canDamaged = true;

    public int ExistSa { get { return existSa; } set { existSa = value; if (existSa == 0) shield.SetActive(false); } }

    public bool CanDamaged { get {  return canDamaged; } set { canDamaged = value; } }

    Coroutine skill;

    private void Start()
    {
        // �ѳ����� ���϶�
        if (gameObject.layer == LayerMask.NameToLayer("Han"))
        {
            ExistSa = Manager.JanggiTurn.HanSa;
        }
        // �ʳ����� ���� ��
        else
        {
            ExistSa = Manager.JanggiTurn.ChoSa;
        }
    }

    public override void TakeDamage(float damage)
    {
        if (!canDamaged) 
        {
            return;
        }

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

    protected override void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            skill = StartCoroutine(Skill());
            base.OnSkill(value);
        }
    }
}
