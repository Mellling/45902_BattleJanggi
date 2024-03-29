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
    Vector2 thisVec;

    bool onPiece;
    string whosPiece;   // tag = cho, han �ʳ��� �ѳ���

    public Piece WhatPiece {  get { return whatPiece; } }
    public string WhosePiece { get { return whosPiece;} set { whosPiece = value; } }
    public Vector2 ThisVec { get { return thisVec; } }

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

    /// <summary>
    /// �� spot�� �ڱ��ڽ��� ��ġ�� ����ϰ� �ϴ� �Լ�
    /// </summary>
    /// <param name="z"></param>
    /// <param name="x"></param>
    public void SetVec(int z, int x)
    {
        thisVec = new Vector2(z,x);
    }    
}
