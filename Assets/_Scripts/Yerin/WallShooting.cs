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
            animator.enabled = true;
            isTargeting = true;
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            animator.enabled = false;
            isTargeting = false;
            target = null;
        }
    }
}
