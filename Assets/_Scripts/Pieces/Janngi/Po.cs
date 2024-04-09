using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Yerin
/// 
/// ��(��⸻) ���� Ŭ����
/// </summary>

public class Po : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // ���� �ִ� Spot�� �迭 ��ġ (== ���� ���� ��ġ)

    protected override void Start()
    {
        base.Start();
        pieceName = "Po";
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
        PoLogic();
    }

    private void PoLogic()
    {
        // ���� x ��ǥ ���� �� ���� �� �˻�

        for (int x = currentPos['x'] - 1; x >= 0; x--)
        {
            bool checkStop = false;     // �˻� �ʿ� ���� Ȯ�� ����

            if (JanggiSituation[currentPos['z'], x].OnPiece)    // ã�� ��ο� ���� �ִ��� �˻�
            {
                if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po"))   // �ִ� ���� ������ �˻�
                {
                    break;  // ���Ͻ� �ߴ�
                }

                x--;

                for (; x >= 0; x--)
                {
                    if (JanggiSituation[currentPos['z'], x].OnPiece)    // �ǳ� �� �ʸӿ� ���� �ִ��� �˻�
                    {
                        if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po") || JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))   // ���� ���ų� �� ���� ���
                        {
                            checkStop = true;
                            break;
                        }
                        else if (!JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))     // ���� ����� ���� ���
                        {
                            checkStop = true;
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
            }

            if (checkStop)
            {
                break;
            }
        }

        // ���� x ��ǥ ���� �� ū �� �˻�

        for (int x = currentPos['x'] + 1; x < 9; x++)
        {
            bool checkStop = false;

            if (JanggiSituation[currentPos['z'], x].OnPiece)
            {
                if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po"))
                {
                    break;
                }

                x++;

                for (; x < 9; x++)
                {
                    if (JanggiSituation[currentPos['z'], x].OnPiece)
                    {
                        if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po") || JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
                            break;
                        }
                        else if (!JanggiSituation[currentPos['z'], x].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
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
            }

            if (checkStop)
            {
                break;
            }
        }

        // ���� z ��ǥ ���� �� ���� �� �˻�

        for (int z = currentPos['z'] + 1; z < 10; z++)
        {
            bool checkStop = false;

            if (JanggiSituation[z, currentPos['x']].OnPiece)
            {
                if (JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po"))
                {
                    break;
                }

                z++;

                for (; z < 10; z++)
                {
                    if (JanggiSituation[z, currentPos['x']].OnPiece)
                    {
                        if (JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po") || JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
                            break;
                        }
                        else if (!JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
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

            if (checkStop)
            {
                break;
            }
        }

        // ���� z ��ǥ ���� �� ū �� �˻�

        for (int z = currentPos['z'] - 1; z >= 0; z--)
        {
            bool checkStop = false;

            if (JanggiSituation[z, currentPos['x']].OnPiece)
            {
                if (JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po"))
                {
                    break;
                }

                z--;

                for (; z >= 0; z--)
                {
                    if (JanggiSituation[z, currentPos['x']].OnPiece)
                    {
                        if (JanggiSituation[z, currentPos['x']].WhatPiece.PieceName.Equals("Po") || JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
                            break;
                        }
                        else if (!JanggiSituation[z, currentPos['x']].WhosePiece.Equals(WhosPiece))
                        {
                            checkStop = true;
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

            if (checkStop)
            {
                break;
            }
        }
    }
}
