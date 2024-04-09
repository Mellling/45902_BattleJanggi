using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ������: Yerin
/// 
/// Weapon ���� ����
/// </summary>
public class Weapon : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] Animator animator;

    [Header("Property")]
    [SerializeField] float damage;

    public float Damage { get { return damage; } }

    public virtual void Fire() { }
}
