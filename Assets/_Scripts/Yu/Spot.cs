using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{

    // ���� ���� �⹰�� �ִ��� ������?
    // �⹰�� �ִٸ�
    // �⹰�� ���̾ �޾ƿ´�

    [SerializeField] LayerMask playerCheck;

    Piece whatPiece;

    bool onPiece;
    string whosPiece;   // tag = cho, han �ʳ��� �ѳ���

    public Piece WhatPiece {  get { return whatPiece; } }
    public string WhosePiece { get { return whosPiece;} set { whosPiece = value; } }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))        // �⹰�� �ִٸ�
        {
            // �⹰�� ���� �ִٴ� bool�� true�� �ٲ��ش�
            onPiece = true;
            // �� ���� �⹰�� �±׸� ������
            whosPiece = other.gameObject.tag;
            // � �⹰���� �޾ƿ���
            whatPiece = other.GetComponent<Piece>();
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
