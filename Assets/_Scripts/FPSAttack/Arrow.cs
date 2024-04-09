using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// ��⸻(��) ���� ��� ȭ�� ���� Ŭ����
/// </summary>
public class Arrow : Bullet
{
    Coroutine destroy;

    public void Shoot(Vector3 dir)
    {
        Bow bow = Weapon.GetComponent<Bow>();
        Rigid.AddForce(dir * Speed * bow.BowPower());
    }

    IEnumerator arrowDestroy()
    {
        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
