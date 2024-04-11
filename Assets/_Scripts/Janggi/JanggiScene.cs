using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ������: Yerin
/// 
/// FPS������ �������� ��ȯ
/// </summary>
public class JanggiScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void SceneChange(string sceneName)
    {
        Manager.Scene.LoadScene(sceneName);

        foreach (GameObject piece in Manager.JanggiLogic.CurrentPieceList)
        {
            piece.transform.position = Manager.JanggiLogic.CurrentPiecePosi[piece];
        }
    }
}
