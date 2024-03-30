using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ma : Piece
{
    [SerializeField] LayerMask checkLayer;

    Spot curSpot;

    List<Spot> CanGoSpots = new List<Spot>();

    // spot�� ������ �� �ش� ������ �������� �����ͼ� ������ ���������� �ʱ�ȭ
    private void OnTriggerEnter(Collider other)
    {
        if (checkLayer.Contain(other.gameObject.layer))
        {
            curSpot = other.GetComponent<Spot>();
        }
    }

    /// <summary>
    /// �����ִ� spot�� ����Ʈ�� �ְ� ���������� ǥ�����ش�
    /// </summary>
    /// <param name="destSpot"></param>
    void AddList(Spot destSpot)
    {
        destSpot.GetComponent<Renderer>().material.color = Color.red;
        CanGoSpots.Add(destSpot);
    }

    public override void FindCanGo()
    {
        MaLogic();
    }

    void MaLogic()
    {
        if (curSpot == null)
        {
            Debug.Log("null");
            return;
        }
        // �� ĭ�� �� �� �ִ��� Ȯ���Ѵ�
        if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x']].OnPiece == false)    // �� �� �ִٸ�?
        {
            //  ���� �밢
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].OnPiece == false ||            // ĭ�� ����ְų�
                !Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].WhosePiece.Equals(WhosPiece))  // ��� �⹰�̸�
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1]);          // CanGoSpots ����Ʈ�� �ְ� ���� �ٲ��ش�
            }
            // ���� �밢
            if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].OnPiece == false ||
                !Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].WhosePiece.Equals(WhosPiece))
            {
                AddList(Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1]);
            }
        }

        // ������ ĭ�� �� �� �ִ��� Ȯ���Ѵ�
        if (Manager.JanggiLogic.JanggiLogicSituation[curSpot.ThisPos['z'], curSpot.ThisPos['x'] +1].OnPiece == false)       // �� �� �ִٸ�?
        {
            // �� �밢
            if (Manager.JanggiLogic.JanggiLogicSituation)
        }
        // �밢���� Ȯ���Ѵ�
        // �Ʊ� �⹰�̸� �������� �Ѿ��
        // �� ĭ�̰ų� ��� �⹰�̸� �̵� ���� ǥ�ø� ���ش�
    }
}
