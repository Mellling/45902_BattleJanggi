using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sang : Piece
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
        if (curSpot.ThisPos['z'] - 3 >= 0 && !JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x']].OnPiece)    // ������� ����� �ʰ� �� �� �ִٸ�?
        {
            //  ���� �밢
            if (curSpot.ThisPos['x'] - 2 >= 0)  // ������� ����� �ʰ�
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 1].OnPiece)           // ĭ�� ���������                    
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] - 2].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] - 2].WhosePiece.Equals(WhosPiece))      // �޴밢 �ѹ� �� üũ
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] - 2]);          // CanGoSpots ����Ʈ�� �ְ� ���� �ٲ��ش�
                    }
                }
            }
            // ���� �밢
            if (curSpot.ThisPos['x'] + 2 <= 8)  // ������� ����� �ʰ�
            {
                if (JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 1].OnPiece == false)
                {
                    if (JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] + 2].OnPiece == false ||
                        !JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] + 2].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] - 3, curSpot.ThisPos['x'] + 2]);
                    }
                }
            }
        }

        // ������ ĭ�� �� �� �ִ��� Ȯ���Ѵ�
        if (curSpot.ThisPos['x'] + 3 <= 8 && !JanggiSituation[curSpot.ThisPos['z'], curSpot.ThisPos['x'] + 1].OnPiece)       // ������� ����� �ʰ� �� �� �ִٸ�?
        {
            // �� �밢
            if (curSpot.ThisPos['z'] - 2 >= 0)      // ������� ����� �ʰ�
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] + 2].OnPiece)           // ĭ�� ����ְų�                     
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 3].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 3].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] + 3]);
                    }
                }
            }
            // �Ʒ� �밢
            if (curSpot.ThisPos['z'] + 2 <= 9)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] + 2].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 3].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 3].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 3]);
                    }
                }
            }
        }

        // �Ʒ� ĭ�� �� �� �ִ��� Ȯ���Ѵ�
        if (curSpot.ThisPos['z'] + 3 <= 9 && !JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x']].OnPiece)
        {
            // ���� �밢
            if (curSpot.ThisPos['x'] + 2 <= 8)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] + 1].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] + 2].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] + 2].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] + 2]);
                    }
                }
            }
            // ���� �밢
            if (curSpot.ThisPos['x'] - 2 >= 0)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 1].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] - 2].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] - 2].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] + 3, curSpot.ThisPos['x'] - 2]);
                    }
                }
            }
        }

        // ���� ĭ�� �� �� �ִ��� Ȯ���Ѵ�
        if (curSpot.ThisPos['x'] - 3 >= 0 && !JanggiSituation[curSpot.ThisPos['z'], curSpot.ThisPos['x'] - 1].OnPiece)
        {
            // �Ʒ� �밢
            if (curSpot.ThisPos['z'] + 2 <= 9)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] + 1, curSpot.ThisPos['x'] - 2].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 3].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 3].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] + 2, curSpot.ThisPos['x'] - 3]);
                    }
                }
            }
            // �� �밢
            if (curSpot.ThisPos['z'] - 2 >= 0)
            {
                if (!JanggiSituation[curSpot.ThisPos['z'] - 1, curSpot.ThisPos['x'] - 2].OnPiece)
                {
                    if (!JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 3].OnPiece ||
                        !JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 3].WhosePiece.Equals(WhosPiece))
                    {
                        AddList(JanggiSituation[curSpot.ThisPos['z'] - 2, curSpot.ThisPos['x'] - 3]);
                    }
                }
            }
        }
    }
}
