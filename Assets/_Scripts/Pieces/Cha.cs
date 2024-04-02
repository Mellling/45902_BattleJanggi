using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// ��(��⸻) ���� Ŭ����
/// </summary>
public class Cha : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // ���� �ִ� Spot�� �迭 ��ġ (== ���� ���� ��ġ)

    protected override void Start()
    {
        base.Start();
        pieceName = "Cha";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (checkSpot.Contain(other.gameObject.layer))
        {
            //transform.position = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            currentPos = other.gameObject.GetComponent<Spot>().ThisPos;
        }
    }

    public override void FindCanGo()
    {
        ChaLogic();
    }

    private void ChaLogic()
    {
        // ���� x ��ǥ ���� �� ���� �� �˻�

        for (int x = currentPos['x'] - 1; x >= 0; x--)
        {
            if (JanggiSituation[currentPos['z'], x].OnPiece)    // ã�� ��ο� ���� �ִ��� �˻�
            {
                if (JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))   // �� ������ �˻�
                {
                    break; 
                }
                else
                {
                    JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'], x]);

                    break;
                }
            }
            else
            {
                JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], x]);
            }
        }

        // ���� x ��ǥ ���� �� ū �� �˻�

        for (int x = currentPos['x'] + 1; x < 9; x++)
        {
            if (JanggiSituation[currentPos['z'], x].OnPiece)    // ã�� ��ο� ���� �ִ��� �˻�
            {
                if (JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))   // �� ������ �˻�
                {
                    break;
                }
                else
                {
                    JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[currentPos['z'], x]);

                    break;
                }
            }
            else
            {
                JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[currentPos['z'], x]);
            }
        }

        // ���� z ��ǥ ���� �� ���� �� �˻�

        for (int z = currentPos['z'] + 1; z < 10; z++)
        {
            if (JanggiSituation[z, currentPos['x']].OnPiece)    // ã�� ��ο� ���� �ִ��� �˻�
            {
                if (JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))   // �� ������ �˻�
                {
                    break;
                }
                else
                {
                    JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[z, currentPos['x']]);

                    break;
                }
            }
            else
            {
                JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[z, currentPos['x']]);
            }
        }

        // ���� z ��ǥ ���� �� ū �� �˻�

        for (int z = currentPos['z'] - 1; z >= 0; z--)
        {
            if (JanggiSituation[z, currentPos['x']].OnPiece)    // ã�� ��ο� ���� �ִ��� �˻�
            {
                if (JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))   // �� ������ �˻�
                {
                    break;
                }
                else
                {
                    JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                    AddList(JanggiSituation[z, currentPos['x']]);

                    break;
                }
            }
            else
            {
                JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;

                AddList(JanggiSituation[z, currentPos['x']]);
            }
        }
    }
}
