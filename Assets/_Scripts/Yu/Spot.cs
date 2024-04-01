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

    Piece whatPiece;
    Dictionary<char, int> thisPos;
    Piece listPiece;

    [SerializeField] bool onPiece;
    [SerializeField] bool checkCanGo;           // �����ִ� üũ����Ʈ�� ������ �Ǿ����� üũ
    string whosPiece;   // tag = cho, han �ʳ��� �ѳ���

    public Piece WhatPiece {  get { return whatPiece; } }
    public string WhosePiece { get { return whosPiece;} set { whosPiece = value; } }
    public bool OnPiece { get { return onPiece; } }
    public bool ChaeckCanGo { get { return checkCanGo; } set { checkCanGo = value; } }
    public Dictionary<char, int> ThisPos { get { return thisPos; } }

    private void Start()
    {
        thisPos = new Dictionary<char, int>();

        thisPos.Add('z', 0);
        thisPos.Add('x', 0);
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
}
