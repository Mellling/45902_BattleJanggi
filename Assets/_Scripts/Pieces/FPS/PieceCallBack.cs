using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// FPS ��⸻ ���� �ִϸ��̼��� ���� Ŭ����
/// ���� �ִϸ��̼� ���� �� isJump�� false�� ����
/// </summary>
public class PieceCallBack : MonoBehaviour
{
    FPSPiece player;

    private void Start()
    {
        player = GetComponentInParent<FPSPiece>();
    }

    void CallBack()
    {
        player.makeIsJumpingFalse();
    }
}
