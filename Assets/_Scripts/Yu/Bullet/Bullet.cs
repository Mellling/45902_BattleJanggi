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

    [Header("Spec")]
    [SerializeField] float damage;
    [SerializeField] float speed;

    public float Damage { get { return damage; } set {  damage = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
}
