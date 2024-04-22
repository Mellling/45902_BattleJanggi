using UnityEngine;
/// <summary>
/// ���� : ����
/// �� ������ �¸����� üũ
/// </summary>
public class GameManager : Singleton<GameManager>
{
    string fpsWin;          // fps �¸�
    string gameWin;         // ��ü ���� �¸�

    public string FpsWin {  get { return fpsWin; } set { fpsWin = value; } }
    public string GameWin { get { return gameWin; } set { gameWin = value; } }

    public void FpsWinReset()
    {
        FpsWin = null;
    }

    public void GameWinReset()
    {
        GameWin = null;
    }

    public bool debugMode;
}
