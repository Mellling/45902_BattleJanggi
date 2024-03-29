using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{

    // ���� ���� �⹰�� �ִ��� ������?
    // �⹰�� �ִٸ�
    // �⹰�� ���̾ �޾ƿ´�

    [SerializeField] LayerMask playerCheck;

    bool onPiece;
    string whosPiece;   // tag = cho, han �ʳ��� �ѳ���

    public string WhosePiece { get { return whosPiece;} set { whosPiece = value; } }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))        // �⹰�� �ִٸ�
        {
            onPiece = true;
            // �� ���� �⹰�� �±׸� ������
            whosPiece = other.gameObject.tag;
        }
    }



    void ComparePiece()
    {
        //if ()
        //{
        //    // �ʳ��� �⹰��
        //}
        //else
        //{
        //    // �ѳ��� �⹰��
        //}


    }
}
