using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// ȭ�� ���� Ŭ����
/// </summary>
public class Arrow : Bullet
{
    public void Shoot(Vector3 dir)
    {
        Bow bow = Weapon.GetComponent<Bow>();
        Rigid.AddForce(dir * Speed * bow.BowPower());
    }
}
