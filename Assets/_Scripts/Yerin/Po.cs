using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Po : Piece
{
    [SerializeField] LayerMask checkSpot;

    Dictionary<char, int> currentPos;  // ���� �ִ� Spot�� �迭 ��ġ (== ���� ���� ��ġ)
    List<int> CanGoSpots;   // �� �� �ִ� Spot�� ��ġ ����

    protected override void Start()
    {
        base.Start();
        pieceName = "Po";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (checkSpot.Contain(other.gameObject.layer))
        {
            // gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, gameObject.transform.position.y , other.gameObject.transform.position.z);
            currentPos = other.gameObject.GetComponent<Spot>().ThisPos;
        }
    }

    public override void FindCanGo()
    {
        // ���� x ��ǥ ���� �� ���� �� �˻�

        for (int x = currentPos['x'] - 1; x >= 0 ; x--)
        {
            bool checkStop = false;

            if (JanggiSituation[currentPos['z'], x].OnPiece)
            {
                if (JanggiSituation[currentPos['z'], x].WhatPiece.PieceName.Equals("Po"))
                {
                    Debug.Log("This is Po");
                    break;
                }

                x--;

                for (; x >= 0; x--)
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
                            Debug.Log($"({currentPos['z']},{x}) 2");
                            JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;
                            break;
                        }
                    }
                    else
                    {
                        Debug.Log($"({currentPos['z']},{x}) 1");
                        JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;
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
                    Debug.Log("This is Po");
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
                            Debug.Log($"({currentPos['z']},{x}) 2");
                            JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;
                            break;
                        }
                    }
                    else
                    {
                        Debug.Log($"({currentPos['z']},{x}) 1");
                        JanggiSituation[currentPos['z'], x].gameObject.GetComponent<Renderer>().material.color = Color.red;
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
                    Debug.Log("This is Po");
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
                            Debug.Log($"({currentPos['x']},{z}) 2");
                            JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;
                            break;
                        }
                    }
                    else
                    {
                        Debug.Log($"({currentPos['x']},{z}) 1");
                        JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;
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
                    Debug.Log("This is Po");
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
                            Debug.Log($"({currentPos['x']},{z}) 2");
                            JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;
                            break;
                        }
                    }
                    else
                    {
                        Debug.Log($"({currentPos['x']},{z}) 1");
                        JanggiSituation[z, currentPos['x']].gameObject.GetComponent<Renderer>().material.color = Color.red;
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
