using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : ChanGyu
/// ���Ʈ������ źȯ
/// </summary>
public class ARBullet : Bullet
{
    private void Start()
    {
        Speed = 30f;
    }

    private void OnEnable()
    {
        Rigid.AddForce(Vector3.forward * Speed);
    }
}
