using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine;
/// <summary>
/// ���� : ����
/// ��� �� (��)�� ��ų ���� ������ ����Ʈ
/// </summary>
public class PoSkillImpact : MonoBehaviour
{
    [SerializeField] float damage;

    public float Damage { get { return damage; } }

    private void Start()
    {
        StartCoroutine(AttackFlow());
    }

    /// <summary>
    /// ���������� üũ�ؼ� �÷��̾ ������ �������� �ְ�
    /// ���� ������ �ش� ���� �μ���
    /// </summary>
    Collider[] colliders = new Collider[50];
    public void AtomicBombAttack()
    {
        int size = Physics.OverlapSphereNonAlloc(transform.position, 12f, colliders);
        for (int i = 0; i < size; i++)
        {
            FPSPiece player = colliders[i].GetComponent<FPSPiece>();
            Wall wall = colliders[i].GetComponent<Wall>();
            Debug.Log(damage);
            player?.TakeDamage(damage);
            wall?.DestroySelf();
        }
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    IEnumerator AttackFlow()
    {
        yield return new WaitForSeconds(1.5f);

        AtomicBombAttack();

        yield return new WaitForSeconds(4f);

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 12f);
    }
}
