using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// ��(��⸻) ���� Ŭ����
/// </summary>
public class Jol : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // ���� �ִ� Spot�� �迭 ��ġ (== ���� ���� ��ġ)

    protected override void Start()
    {
        base.Start();
        pieceName = "Jol";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (checkSpot.Contain(other.gameObject.layer))
        {
            currentPos = other.gameObject.GetComponent<Spot>().ThisPos;
        }
    }

    public override void FindCanGo()
    {
        JolLogic();
    }

    private void JolLogic()
    {
        // ���� ���� Ȯ��

        if (currentPos['x'] != 0)
        {
            if (JanggiSituation[currentPos['z'], currentPos['x'] - 1].OnPiece)
            {
                if (!JanggiSituation[currentPos['z'], currentPos['x'] - 1].WhosePiece.Equals(WhosPiece))
                {
                    JanggiSituation[currentPos['z'], currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'], currentPos['x'] - 1]);
                }
            }
            else
            {
                JanggiSituation[currentPos['z'], currentPos['x'] - 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], currentPos['x'] - 1]);
            }
        }

        // ���� ������ Ȯ��
        if (currentPos['x'] != 8)
        {
            if (JanggiSituation[currentPos['z'], currentPos['x'] + 1].OnPiece)
            {
                if (!JanggiSituation[currentPos['z'], currentPos['x'] + 1].WhosePiece.Equals(WhosPiece))
                {
                    JanggiSituation[currentPos['z'], currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'], currentPos['x'] + 1]);
                }
            }
            else
            {
                JanggiSituation[currentPos['z'], currentPos['x'] + 1].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], currentPos['x'] + 1]);
            }
        }

        // ���� ���� Ȯ��
        if (WhosPiece.Equals("Cho"))    // �ʳ��� ���� ���
        {
            if (currentPos['z'] == 9)
            {
                return;
            }

            if (JanggiSituation[currentPos['z'] + 1, currentPos['x']].OnPiece)  // �ش� ��ο� ���� �ִ��� Ȯ��
            {
                if (!JanggiSituation[currentPos['z'] + 1, currentPos['x']].WhosePiece.Equals(WhosPiece))    // ����� ���̸�
                {
                    JanggiSituation[currentPos['z'] + 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x']]);
                }
            }
            else
            {
                JanggiSituation[currentPos['z'] + 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] + 1, currentPos['x']]);
            }
        }
        
        if (WhosPiece.Equals("Han"))    // �ѳ��� ���� ���
        {
            if (currentPos['z'] == 0)
            {
                return;
            }

            if (JanggiSituation[currentPos['z'] - 1, currentPos['x']].OnPiece)  // �ش� ��ο� ���� �ִ��� Ȯ��
            {
                if (!JanggiSituation[currentPos['z'] - 1, currentPos['x']].WhosePiece.Equals(WhosPiece))    // ����� ���̸�
                {
                    JanggiSituation[currentPos['z'] - 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x']]);
                }
            }
            else
            {
                JanggiSituation[currentPos['z'] - 1, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'] - 1, currentPos['x']]);
            }
        }
    }
}
