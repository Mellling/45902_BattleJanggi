using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLoadManager : MonoBehaviour
{
    [SerializeField] FPSSpotSetting spots;

    public void PieceLoad()
    {
        Manager.Data.LoadData(1);
        PieceData data = Manager.Data.GameData.pieceData;
        foreach (PiecePosData piece in data.pieces)
        {
            if (!piece.isPlayerPiece)       // �÷��̾�� �⹰�� �ƴϸ� 
            {
                // �⹰�� �̸��� üũ
                switch (piece.pieceName)
                {
                    case "Cha":
                        Wall instanceCha = Manager.Resource.Load<Wall>("Wall/ChaWall_Complete");
                        Instantiate(instanceCha, spots.FPSLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;
                    case "Sang":
                        Wall instanceSang = Manager.Resource.Load<Wall>("Wall/SangWall_Complete");
                        Instantiate(instanceSang, spots.FPSLogicSituation[piece.z, piece.x].transform.position, Quaternion.identity);
                        break;

                }
                // �ش� ��ġ�� ���� �������ְ�
            }
            else                            // �÷��̾�� �⹰�̸� 
            {
                // FPS�⹰�� �������ش�
            }
        }
    }
}
