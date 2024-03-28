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
    string whosPiece;   // tag = cho, han �ʳ��� �Ѵٶ�

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))        // �⹰�� �ִٸ�
        {
            onPiece = true;
            // �� ���� �⹰�� �±׸� ������
            whosPiece = other.gameObject.tag;
        }
    }

    

    /* ���ϴ� �Լ�
     * if(other.CompareTag("cho"))
            {
                // �ʳ��� �⹰��
            }
            else
            {
                // �ѳ��� �⹰��
            }
    */
}
