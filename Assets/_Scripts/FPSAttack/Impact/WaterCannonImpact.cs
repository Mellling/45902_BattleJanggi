using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������ : ChanGyu
/// ������ ��ź �� ������ ����Ʈ
/// </summary>
public class WaterCannonImpact : Impact
{
    [SerializeField] new Collider collider;
    [SerializeField] float damage;

    private void OnEnable()
    {
        StartCoroutine(SetOff());
        StartCoroutine(CollSet());
    }

    IEnumerator SetOff()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    IEnumerator CollSet()
    {
        collider.enabled = true;

        yield return new WaitForSeconds(0.1f);

        collider.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        FPSPiece target;
        collision.gameObject.TryGetComponent<FPSPiece>(out target);

        target?.TakeDamage(damage);
    }
}
