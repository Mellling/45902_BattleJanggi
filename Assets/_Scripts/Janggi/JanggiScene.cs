using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ������: Yerin
/// 
/// �������� FPS������ ��ȯ
/// </summary>
public class JanggiScene : BaseScene
{
    private void Start()
    {
        PieceLoad();
    }

    public override IEnumerator LoadingRoutine()
    {
        Manager.Data.LoadData(0);
        yield return null;
    }

    public void SceneChange(string sceneName)
    {
        DataSave();
        Manager.Scene.LoadScene(sceneName);
    }

    void DataSave()
    {
        List<Spot> spotList = new List<Spot>();

        foreach (Spot spot in Manager.JanggiLogic.JanggiLogicSituation)
        {
            if (spot.OnPiece)
            {
                spotList.Add(spot);
            }
        }

        Manager.Data.GameData.pieceData.PieceSave(spotList);
        Manager.Data.GameData.isSaved = true;
        Manager.Data.SaveData(1);
    }

    public void PieceLoad()
    {
        Manager.Data.LoadData(1);
        PieceData data = Manager.Data.GameData.pieceData;
        foreach (PiecePosData piece in data.pieces)
        {
            // �⹰�� �̸��� üũ

            // �⹰�� ������ üũ

            // �ش� �⹰�� ���ҽ� �Ŵ����� ã�Ƽ� ����
        }
    }
}
