using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : ����
/// ������ ��������� ���Ǵ� ���� �Լ���
/// </summary>
public class EndScene : BaseScene
{
    string winner;

    public string Winner { get { return winner; } }
    /// <summary>
    /// ���ӸŴ������� ���ڰ� ������ �޾ƿ´�
    /// </summary>
    private void Awake()
    {
        if (Manager.Game.GameWin == "Han")
        {
            winner = "Han";
        }
        else
        {
            winner = "Cho";
        }

        // �ٽ� ������ ������ �� �ְ� �ʱ�ȭ �۾��� �ʿ��� �̱����� ���� gameObject���� ����
        Destroy(Manager.JanggiLogic.gameObject);
        Destroy(Manager.KillListManager.gameObject);
        Destroy(Manager.JanggiTurn.gameObject);
        Destroy(Manager.JanggiLoadManager.gameObject);
    }
    /// <summary>
    /// �������� ���
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
    /// <summary>
    /// ��Ƽ���� ������ Ÿ��Ʋ������ ���� �Լ�
    /// </summary>
    public void GoTitle()
    {
        Manager.Scene.LoadScene("TitleScene");
    }    
}
