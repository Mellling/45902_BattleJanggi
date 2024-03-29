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
    Dictionary<char, int> thisPos;

    bool onPiece;
    string whosPiece;   // tag = cho, han �ʳ��� �ѳ���

    public Piece WhatPiece {  get { return whatPiece; } }
    public string WhosePiece { get { return whosPiece;} set { whosPiece = value; } }
    public bool OnPiece { get { return onPiece; } }
    public Dictionary<char, int> ThisPos { get { return thisPos; } }

    private void Start()
    {
        thisPos = new Dictionary<char, int>();
    }

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
    public void SetPos(int z, int x)
    {
        thisPos.Add('z', z);
        thisPos.Add('x', x);
    }    
}
