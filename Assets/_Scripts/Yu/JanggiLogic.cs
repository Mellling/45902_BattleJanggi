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

    public Spot[,] JanggiLogicSituation { get { return spots; } }
    public bool ClickedPieceExist { get { return clickedPieceExist; } set { clickedPieceExist = value; } }
    public Piece ClickedPiece { get { return clickedPiece; } set { clickedPiece = value; } }

    /// <summary>
    /// ������ ���۵ɶ� 
    /// </summary>
    void Start()
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

        Manager.JanggiLoadManager.LoadStart();
    }    
}
