using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : ChanGyu
/// �ѿ��� ������ źȯ�� �⺻ ���̽�
/// </summary>
public class Bullet : PooledObject
{
    [Header("Component")]
    [SerializeField] Weapon weapon;
    [SerializeField] Rigidbody rigid;

    [Header("Spec")]
    [SerializeField] float speed;
    float damage;

    public Weapon Weapon { get { return weapon; } set { weapon = value; } }
    public Rigidbody Rigid { get { return rigid; } }
    public float Damage { get { return damage; } set {  damage = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
}
