using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ma : Piece
{
    [SerializeField] LayerMask checkLayer;

    Spot curSpot;       // ���� �ִ� ������ ������ ������ ����

    protected override void Start()
    {
        base.Start();
        pieceName = "Ma";
    }

    // spot�� ������ �� �ش� ������ �������� �����ͼ� ������ ���������� �ʱ�ȭ
    private void OnTriggerEnter(Collider other)
    {
        if (checkLayer.Contain(other.gameObject.layer))
        {
            curSpot = other.GetComponent<Spot>();
        }
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
        if (curSpot.ThisPos['z'] - 2 >= 0 && !JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x']].OnPiece)    // ������� ����� �ʰ� �� �� �ִٸ�?
        {
            //  ���� �밢
            if (curSpot.ThisPos['x'] - 1 >= 0)  // ������� ����� �ʰ�
            {
                if (JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].OnPiece == false ||            // ĭ�� ����ְų�
                    !JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].WhosePiece.Equals(WhosPiece))  // ��� �⹰�̸�
                {
                    AddList(JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1]);          // CanGoSpots ����Ʈ�� �ְ� ���� �ٲ��ش�
                }
            }
            // ���� �밢
            if (curSpot.ThisPos['x'] + 1 <= 8)  // ������� ����� �ʰ�
            {
                if (JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].OnPiece == false ||
                    !JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].WhosePiece.Equals(WhosPiece))
                {
                    AddList(JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1]);
                }
            }
        }

        // ������ ĭ�� �� �� �ִ��� Ȯ���Ѵ�
        if (curSpot.ThisPos['x'] + 2 <= 8 && JanggiSituation[curSpot.ThisPos['z'], curSpot.ThisPos['x'] + 1].OnPiece == false)       // ������� ����� �ʰ� �� �� �ִٸ�?
        {
            // �� �밢
            if (curSpot.ThisPos['z'] - 1 >= 0)      // ������� ����� �ʰ�
            {
                if (JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] + 2].OnPiece == false ||            // ĭ�� ����ְų�
                    !JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] + 2].WhosePiece.Equals(WhosPiece)) // ��� �⹰�̸�
                {
                    AddList(JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] + 2]);
                }
            }
            // �Ʒ� �밢
            if (curSpot.ThisPos['z'] + 1 <= 9)
            {
                if (JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] + 2].OnPiece == false ||
                    !JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] + 2].WhosePiece.Equals(WhosPiece))
                {
                    AddList(JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] + 2]);
                }
            }
        }

        // �Ʒ� ĭ�� �� �� �ִ��� Ȯ���Ѵ�
        if (curSpot.ThisPos['z'] + 2 <= 9 && JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x']].OnPiece == false)
        {
            // ���� �밢
            if (curSpot.ThisPos['x'] + 1 <= 8)
            {
                if (JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 1].OnPiece == false ||
                    !JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 1].WhosePiece.Equals(WhosPiece))
                {
                    AddList(JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 1]);
                }
            }
            // ���� �밢
            if (curSpot.ThisPos['x'] - 1 >= 0)
            {
                if (JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 1].OnPiece == false ||
                   !JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 1].WhosePiece.Equals(WhosPiece))
                {
                    AddList(JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 1]);
                }
            }
        }

        // ���� ĭ�� �� �� �ִ��� Ȯ���Ѵ�
        if (curSpot.ThisPos['x'] - 2 >= 0 && JanggiSituation[curSpot.ThisPos['z'], curSpot.ThisPos['x'] - 1].OnPiece == false)
        {
            // �Ʒ� �밢
            if (curSpot.ThisPos['z'] - 1 >= 0)
            {
                if (JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] - 2].OnPiece == false ||
                    !JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] - 2].WhosePiece.Equals(WhosPiece))
                {
                    AddList(JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] - 2]);
                }
            }
            // �� �밢
            if (curSpot.ThisPos['z'] + 1 <= 9)
            {
                if (JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] - 2].OnPiece == false ||
                    !JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] - 2].WhosePiece.Equals(WhosPiece))
                {
                    AddList(JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] - 2]);
                }
            }
        }
    }
}
