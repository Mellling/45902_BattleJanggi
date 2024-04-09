using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ������: ����
/// 
/// ��⸻(��) ���� Ŭ���� 
/// ��⸻�� ����� �θ� Ŭ������, ���� ���� ��ų
/// </summary>
public class FPSPo : MonoBehaviour
{
    [SerializeField] LayerMask wallCheck;
    [SerializeField] CinemachineVirtualCamera skyCam;
    [SerializeField] ParticleSystem atomicBomb;

    bool isUsing;   // ��ų ����� üũ

    private void Start()
    {
        isUsing = false;
    }

    public void OnSkill(InputValue value)
    {
        if (!isUsing)
        {
            skyCam.Priority = 50;
            isUsing = true;
        }
    }
}
