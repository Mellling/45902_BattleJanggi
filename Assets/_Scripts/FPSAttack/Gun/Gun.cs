using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : changyu
/// źȯ �߻��� ������� ���̽�
/// </summary>
public class Gun : Weapon
{
    [SerializeField] Bullet bullet;         // �ѿ��� ���� źȯ�� ������

    public Bullet Bullet {  get { return bullet; } }
}
