using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;


/// <summary>
/// ChanGyu, Yerin
/// </summary>
public class FPSPiece : MonoBehaviour
{
    [Header("Spec")]
    [SerializeField] float hp;

    [Header("Componemt")]
    [SerializeField] CharacterController controller;
    [SerializeField] Rigidbody rigid;
    [SerializeField] Weapon weapon;
    [SerializeField] CinemachineVirtualCamera curCamera;
    [SerializeField] CinemachineVirtualCamera FPSCamera;
    [SerializeField] CinemachineVirtualCamera ZoomCamera;

    [Header("Property")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float breakPower;
    [SerializeField] float ySpeed;
    
    private Vector3 moveDir;

    private void Start()
    {
        curCamera = FPSCamera;
    }

    private void FixedUpdate()
    {
        Move();
        JumpMove();
    }

    /// <summary>
    /// ChanGyu
    /// �÷��̾� �̵� �Լ�
    /// </summary>
    public void Move()
    {
        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// ChanGyu
    /// ���콺 Ŭ���� ���� �� �߻��ϴ� �Լ�
    /// ��¡���⸦ ���� ������ ���� ������ ����
    /// </summary>
    /// <param name="value"></param>
    void OnFire(InputValue value)
    {
        ChargingWeapon charge;
        if (!weapon.TryGetComponent(out charge))
            charge = null;

        if (value.isPressed)
        {
            if (charge != null)
            {
                charge.Charging();
            }
            else
            {
                weapon.Fire();
            }
        }
        else
        {
            if (charge != null)
            {
                charge.Fire();
            }
        }
    }

    // ��ǲ�׼ǿ��� �޾ƿ��� ����
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        moveDir.x = input.x;
        moveDir.z = input.y;
    }

    // ����
    private void OnJump(InputValue value)
    {        
        ySpeed = jumpSpeed;
    }

    /// <summary>
    /// ������ �����ϴ� �Լ�
    /// </summary>
    void JumpMove()
    {        
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            ySpeed = 0f;
        }

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);      // ���⼭ deltaTime�� �ѹ� �� �����ִϱ� ������ �ȴ�
    }

    /// <summary>
    /// �������� �޴� �Լ�
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp > 0)     // ü���� 0�ʰ��� ����
            return;

        Die();
    }

    /// <summary>
    /// ����ϴ� �Լ�
    /// </summary>
    void Die()
    {

    }

    /// <summary>
    /// ��Ŭ�� �ÿ� ���� ���ְ� ī�޶��� ������ �ٲٴ� �Լ�
    /// </summary>
    /// <param name="value"></param>
    void OnZoom(InputValue value)
    {
        if (curCamera == FPSCamera)
        {
            curCamera = ZoomCamera;
            ZoomCamera.Priority = 11;
        }
        else
        {
            curCamera = FPSCamera;
            ZoomCamera.Priority = 1;
        }
    }
}