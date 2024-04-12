using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// ChanGyu
/// </summary>
public class Spot : MonoBehaviour, IPointerClickHandler
{
    // ���� ���� �⹰�� �ִ��� ������?
    // �⹰�� �ִٸ�
    // �⹰�� ���̾ �޾ƿ´�

    [SerializeField] LayerMask playerCheck;

    Piece whatPiece;        // ���� ���� �ִ� �⹰
    Dictionary<char, int> thisPos;
    Piece listPiece;

    bool inList;
    bool onPiece;
    bool checkCanGo;           // �����ִ� üũ����Ʈ�� ������ �Ǿ����� üũ

    string whosPiece;   // Cho, Han �ʳ��� �ѳ���

    public Piece WhatPiece { get { return whatPiece; } }
    public string WhosePiece { get { return whosPiece; } set { whosPiece = value; } }
    public bool InList { get { return inList; } set { inList = value; } }
    public bool OnPiece { get { return onPiece; } }
    public bool CheckCanGo { get { return checkCanGo; } set { checkCanGo = value; } }
    public Piece ListPiece { get { return listPiece; } }
    public Dictionary<char, int> ThisPos { get { return thisPos; } }

    private void Start()
    {
        thisPos = new Dictionary<char, int>();

        thisPos.Add('z', 0);
        thisPos.Add('x', 0);

        inList = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (playerCheck.Contain(other.gameObject.layer))        // �⹰�� �ִٸ�
        {
            // �⹰�� ���� �ִٴ� bool�� true�� �ٲ��ش�
            onPiece = true;
            // �� ���� �⹰�� ���� ������
            whosPiece = other.gameObject.GetComponent<Piece>().WhosPiece;
            // � �⹰���� �޾ƿ���
            whatPiece = other.GetComponent<Piece>();
            // �� ���� �⹰�� ����spot �����ϱ�
            other.gameObject.GetComponent<Piece>().SetUnderSpot(this);
        }
    }

    private void OnTriggerExit(Collider other)              // �⹰�� ���ٸ�
    {
        if (playerCheck.Contain(other.gameObject.layer))
        {
            onPiece = false;
            whosPiece = null;
            whatPiece = null;
        }
    }

    /// <summary>
    /// �� spot�� �ڱ��ڽ��� ��ġ�� ����ϰ� �ϴ� �Լ�
    /// </summary>
    /// <param name="z"></param>
    /// <param name="x"></param>
    public void SetPos(int z, int x)
    {
        thisPos['z'] = z;
        thisPos['x'] = x;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!checkCanGo)
            return;

        listPiece.MovePiece(this);
    }

    /// <summary>
    /// spot�� ���ִ� list�� ������ �ִ� �⹰�� ����
    /// </summary>
    /// <param name="listPiece"></param>
    public void SetList(Piece listPiece)
    {
        this.listPiece = listPiece;
    }

    public void ClickMove()
    {
        if (!checkCanGo)
            return;

        listPiece.MovePiece(this);

        listPiece = null;
    }
}
