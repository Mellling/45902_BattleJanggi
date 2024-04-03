using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
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
    [SerializeField] Animator animator;
    [SerializeField] LayerMask groundCheck;    

    [Header("Property")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float breakPower;
    [SerializeField] float ySpeed;

    bool isGround;  // �÷��̾��� �� �� ����
    bool isWalking; // �÷��̾��� �ȱ� ����
    bool isJumping; // �÷��̾��� ���� ����
    
    private Vector3 moveDir;      

    private void FixedUpdate()
    {
        Move();        
    }

    /// <summary>
    /// ChanGyu
    /// �÷��̾� �̵� �Լ�
    /// </summary>
    public void Move()
    {
        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);

        if (moveDir.x == 0 && moveDir.z == 0)
        {
            isWalking = false;
        }

        if (isGround)
        {
            if (!isJumping)
            {
                if (isWalking)
                {
                    animator.Play("Walk");
                }
                else
                {
                    animator.Play("Idle A");
                }
            }
            else
            {
                animator.Play("Jump");
            }
        }
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

        isWalking = true;
    }

    // ����
    private void OnJump(InputValue value)
    {       
        ySpeed = jumpSpeed;

        isJumping = true;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (groundCheck.Contain(collision.gameObject.layer))    // �÷��̾ �� ���� ���� ���
        {
            isGround = true;

            if (isJumping)
            {
                isJumping = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (groundCheck.Contain(collision.gameObject.layer))    // �÷��̾ �� ���� ���� ���
        {
            isGround = false;
        }
    }
}