using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Yerin
/// Į ���� ��� ����
/// </summary>
public class Knife : Weapon
{
    [SerializeField] LayerMask checkCanDamaged;

    private void OnCollisionEnter(Collision collision)
    {
        if (checkCanDamaged.Contain(collision.gameObject.layer))
        {
            //collision.gameObject.GetComponent<FPSPiece>().TakeDamage(Damage);
        }
    }
}