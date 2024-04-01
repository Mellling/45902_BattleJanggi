using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Weapon
{
    float value;
    Vector3 lookPos;
    [SerializeField] float speed;

    /// <summary>
    /// ��...
    /// </summary>
    /// <param name="_value">���� �� �ִ� �Ÿ�</param>
    /// <param name="dir"> ���� ����</param>
    public void SetValue(float _value, Vector3 dir)
    {
        value = _value;
        lookPos = dir;
        MoveCo = StartCoroutine(MoveRoutine());
    }
    Coroutine MoveCo;

    IEnumerator MoveRoutine()
    {
        Vector3 desPos = lookPos * value; //�Ÿ� ���(�����ǥ)

        Vector3 absolueDesPos = desPos +transform.position; //������ǥ ��������
        Vector3 currentPos = transform.position;                //������ǥ�����

        Vector3 moveSpeed = (currentPos - absolueDesPos).normalized * speed; //�̵��ӵ�

        float destLength = Vector3.Distance(currentPos, absolueDesPos); //������������ �Ÿ�
        float moveLength = 0;                                            //�̵� �Ÿ�

        while (destLength >= moveLength)                    //������ �Ÿ��� �Ѿ����� Ȯ��
        {
            transform.Translate(moveSpeed); //�̵�
            moveLength += speed;        //�� �̵� �Ÿ�
            yield return null;
        }
        StopCo();
    }

    private void OnTriggerEnter(Collider other) => OnDamage(other);
    private void OnCollisionEnter(Collision collision) => OnDamage(collision.collider);

    void OnDamage(Collider target)
    {
        Piece targetCom = target.GetComponent<Piece>();
        if (targetCom == null)
            return;
        if(targetCom.WhosPiece.Equals("��"))
        {
            StopCo();
        }
        Debug.LogError("��븦 �Ǻ� �Ұ�! ���ǽ� ���� ���");
        UnityEditor.EditorApplication.isPlaying = false;
    }

    /// <summary>
    /// Ǯ���� ��û�մϴ�.
    /// ������, �ƴ� ��츦 ����Ͽ� �ı��� �մϴ�.
    /// </summary>
    void StopCo()
    {
        if (MoveCo != null)
            StopCoroutine(MoveCo);
        Destroy(gameObject);
    }
}
