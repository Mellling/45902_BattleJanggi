using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// ChanGyu, Yerin
/// </summary>
public class FPSPiece : MonoBehaviour
{
    [Header("Spec")]
    [SerializeField] float hp;

    [Header("Componemt")]
    [SerializeField] InputActionAsset inputAction;
    [SerializeField] Rigidbody rigid;

    [Header("Property")]
    [SerializeField] float movePower;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float breakPower;

    [SerializeField] float jumpPower;

    private Vector3 moveDir;

    private void FixedUpdate()
    {
        Move();
    }
     
    /// <summary>
    /// �÷��̾� �̵� �Լ�
    /// </summary>
    public void Move()
    {
        if (moveDir.x == 0 && rigid.velocity.magnitude < 0.001f)
        {
            rigid.velocity = Vector3.zero;
        }

        // x����(�¿�) üũ
        if (moveDir.x < 0 && rigid.velocity.x > -maxMoveSpeed)      // ���� �̵�
        {
            rigid.AddForce(Vector3.right * moveDir.x * movePower);
        }
        else if (moveDir.x > 0 && rigid.velocity.x < maxMoveSpeed)  // ������ �̵�
        {
            rigid.AddForce(Vector3.right * moveDir.x * movePower);
        }
        else if (moveDir.x == 0 && rigid.velocity.x > 0.001f)         // �Է��� ���� �� �ݴ�� ���� �༭ ������ ���߰� �Ͽ� ���۰� ����
        {
            rigid.AddForce(Vector3.left * breakPower);
        }
        else if (moveDir.x == 0 && rigid.velocity.x < -0.001f)        // �Է��� ���� �� �ݴ�� ���� �༭ ������ ���߰� �Ͽ� ���۰� ����
        {
            rigid.AddForce(Vector3.right * breakPower);
        }

        // z����(�յ�) üũ
        if (moveDir.z < 0 && rigid.velocity.z > -maxMoveSpeed)      // �� �̵�
        {
            rigid.AddForce(Vector3.forward * moveDir.z * movePower);
        }
        else if (moveDir.z > 0 && rigid.velocity.z < maxMoveSpeed)  // �� �̵�
        {
            rigid.AddForce(Vector3.forward * moveDir.z * movePower);
        }
        else if (moveDir.z == 0 && rigid.velocity.z > 0.001f)         // �Է��� ���� �� �ݴ�� ���� �༭ ���۰� ����
        {
            rigid.AddForce(Vector3.back * breakPower);
        }
        else if (moveDir.z == 0 && rigid.velocity.z < -0.001f)        // �Է��� ���� �� �ݴ�� ���� �༭ ���۰� ����
        {
            rigid.AddForce(Vector3.forward * breakPower);
        }

        if (rigid.velocity.sqrMagnitude > maxMoveSpeed * maxMoveSpeed)  // �ְ�ӵ� ���Ѱɱ�
        {
            rigid.velocity = rigid.velocity.normalized * maxMoveSpeed;
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
        Debug.Log("������");
        if (value.isPressed)
            Jump();
    }

    /// <summary>
    /// ������ �����ϴ� �Լ�
    /// </summary>
    void Jump()
    {
        Debug.Log("����");                
        rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

    /// <summary>
    /// �������� �޴� �Լ�
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(int damage)
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
}