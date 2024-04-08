using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// ��⸻ ���� ��
/// ���� �ð����� ȭ�� �߻�
/// </summary>
public class WallShooting : Wall
{
    [SerializeField] LayerMask playerCheck;
    [SerializeField] Animator animator;

    [SerializeField] PoAttackRange attackRange;
    [SerializeField] PoAttackRange nonAttackRange;

    [SerializeField] float rotSpeed;

    GameObject target;
    bool isTargeting;

    private void FixedUpdate()
    {
        if(isTargeting && target == null)
        {
            isTargeting = false;
            animator.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            if (attackRange.IsInTrigger)
            {
                if (nonAttackRange.IsInTrigger)
                {
                    SetData();
                }
                else
                {
                    SetData(other.gameObject);
                }
            }
        }
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            if (!attackRange.IsInTrigger)
            {
                SetData();
            }
            else
            {
                SetData(other.gameObject);
            }
        }
    }
    void SetData(GameObject collider = null)
    {
        bool state = collider != null ? true : false;
        animator.enabled = state;
        isTargeting = state;
        target = collider;
    }

    private void OnTriggerStay(Collider other)  // Trigger �ȿ� �ִ� ���� ĳ���� �ٶ󺸰� �ϱ�
    {
        if (playerCheck.Contain(other.gameObject.layer)) 
        {
            Vector3 dir = other.transform.position - transform.position;
            Quaternion currentPos = gameObject.transform.rotation;

            float time = 0;

            while (time <= 1) //�븻 ���� 1�� �ƴϸ� �ݺ��Ѵ�.
            {
                //Ÿ�� ����� ���� �ٶ� ���� �ִ� ������ ���� ������ ������ �븻 ���� ���� �ش� ������ ��ȭ���� �����´�.
                Quaternion rot = Quaternion.Lerp(currentPos, Quaternion.LookRotation(dir), time);
                time += Time.deltaTime * rotSpeed; //�븻 ���� ������Ų��.
                transform.rotation = rot; //������ ��ȭ���� ���Խ�Ų��.
            }

            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}

