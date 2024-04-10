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
    [SerializeField] Bullet waterBalloon;
    [SerializeField] GameObject muzzlePoint;

    Coroutine skill;

    IEnumerator Skill()
    {
        yield return new WaitForSeconds(5f);

        CanUseSkill = true;
        muzzlePoint.SetActive(false);
    }

    private void OnSkill(InputValue value)
    {
        if (CanUseSkill)
        {
            WaterBalloon();

            skill = StartCoroutine(Skill());

            CanUseSkill = false;

            CoolTime(60f);
        }
    }

    private void WaterBalloon()
    {
        muzzlePoint.SetActive(true);

        PooledObject PO = Manager.Pool.GetPool(waterBalloon, muzzlePoint.transform.position, muzzlePoint.transform.rotation);

        PO.GetComponent<WaterBalloon>()?.Shoot(muzzlePoint.transform.forward);
    }
}
