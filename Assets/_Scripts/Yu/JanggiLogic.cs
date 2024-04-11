using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������: Yerin, ChanGyu
/// 
/// ����� ���� ���� �Լ� (�̱���)
/// </summary>
public class JanggiLogic : Singleton<JanggiLogic>
{
    // ������� ���� 9, ���� 10 �� ũ��
    // ������� 2���� �迭�� ����ٸ� 9x10�� �迭�� �����ؾ���

    Spot[,] spots = new Spot[10, 9] 
    {
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null},
        { null, null, null, null, null, null, null, null, null}
    };

    bool clickedPieceExist;
    Piece clickedPiece;

    List<GameObject> currentPieceList;

    Dictionary<GameObject, Vector3> currentPiecePosi;

    public Spot[,] JanggiLogicSituation { get { return spots; } }
    public bool ClickedPieceExist { get { return clickedPieceExist; } set { clickedPieceExist = value; } }
    public Piece ClickedPiece { get { return clickedPiece; } set { clickedPiece = value; } }
    public List<GameObject> CurrentPieceList { get { return currentPieceList; } }
    public Dictionary<GameObject, Vector3> CurrentPiecePosi { get { return currentPiecePosi; } }

    /// <summary>
    /// ������ ���۵ɶ� 
    /// </summary>
    private void Start()
    {
        Spot[] children = GetComponentsInChildren<Spot>();
        for (int z = 0; z < 10; z++)
        {
            for(int x = 0; x < 9; x++)
            {
                if (children[z * 9 + x] == null)
                {
                    Debug.Log($"Null ({x}, {z})");
                    break;
                }

                spots[z, x] = children[z * 9 + x];
                spots[z, x].SetPos(z, x);
            }
        }
    }
    public void GetCurrentPosi()
    {
        foreach (Spot spot in spots)
        {
            if (spot.OnPiece)
            {
                GameObject piece = spot.WhatPiece.gameObject;

                currentPieceList.Add(piece);
                currentPiecePosi.Add(piece, new Vector3(piece.transform.position.x, piece.transform.position.y, piece.transform.position.z));
            }
        }
    }
}
