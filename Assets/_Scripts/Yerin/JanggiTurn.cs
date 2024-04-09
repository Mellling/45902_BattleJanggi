using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// ��� �� �÷ο� - �÷��̾� �� ���� Ŭ����
/// </summary>
public class JanggiTurn : Singleton<JanggiTurn>
{
    string currentTurn;

    string Han = "Han";
    string Cho = "Cho";

    float time;

    Coroutine timeLimit;

    public string CurrentTurn { get { return currentTurn; } }

    private void Start()
    {
        currentTurn = Han;
        time = 0;

        timeLimit = StartCoroutine(CountTime());
    }
    /// <summary>
    /// ���� ������ ������ Ȯ���ϴ� �Լ� 
    /// �ڽ��� ���̸� true��, �ƴ� �� false�� ����
    /// </summary>
    /// <param name="player"> �÷��̾� ����</param>
    /// <returns></returns>
    public bool CheckWhosTurn(string player)
    {
        if (player == null || currentTurn == null)
        {
            Debug.LogError("���� ������ ������ Ȯ���� �� �����ϴ�.");
            return false;
        }

        if (player.Equals(currentTurn))
        {
            return true;
        }
        
        return false;
    }

    /// <summary>
    /// ��� �� �÷��̾��� ���� ����� �Լ� 
    /// </summary>
    public void OnTurn() 
    {
        StopCoroutine(timeLimit);

        if (currentTurn.Equals(Han))    // ���� �÷��̾ �ѳ����� ��
        {
            currentTurn = Cho;
        }
        else if (currentTurn.Equals(Cho))   // ���� �÷��̾ �ʳ����� ��
        {
            currentTurn = Han;
        }
        else
        {
            Debug.LogError("���� �ǹٸ��� �ʴ� �÷��̾� ������ �����ͷ� �ԷµǾ� �ֽ��ϴ�.");
            return;
        }

        timeLimit = StartCoroutine(CountTime());
    }

    IEnumerator CountTime()
    {
        yield return new WaitForSeconds(60.0f);

        Debug.Log("�ð� �ʰ� �߻�");

        if (Manager.JanggiLogic.ClickedPieceExist)  // ��⸻�� ������ ���¿��� �ð��ʰ� �߻� ��
        {
            Manager.JanggiLogic.ClickedPieceExist = false;

            Manager.JanggiLogic.ClickedPiece.PieceMaterial.color = Color.white;
            Manager.JanggiLogic.ClickedPiece.IsClicked = false;

            Manager.JanggiLogic.ClickedPiece.DeleteList();
        }

        OnTurn();
        Manager.JanggiCamera.CameraMoveLow();
    }
}

/*
 * �÷��̾� �� ������ ���� ��� ��
 * 
 * 1. ���� ���� ������ ������ Ȯ�� - ���� �� ������ String �޾Ƶ� - �̰ɷ� Ȯ���ϸ� ��.
 * ��� 1. �̷� �� JanggiScene�� �Ŵ������� �ϴ� �� ���� �ʳ�...? -> �̱��� (�Ϸ�)
 * 
 * 2. �Ͽ� �ش�Ǵ� �� ������ �Ѿ�� (ù ������ �ѳ��󿡼� ����) (�Ϸ�)
 * 
 * 3. �ð� �ʰ�(60��) �Ѿ�� �ٸ� ��� ������ �̵� (�Ϸ�)
 * 
 * 4. �񽺵��ϰ� �����ִ� ���� �����ϸ� ���� �ö󰡱�
 * 
 * 5. ���� ����ϸ� �ٽ� �񽺵��ϰ�, ���� �̵��� ���� �����ϸ� �� �������� �̵��� ������ �� ���� ���� ������� �̵�
 * 
 * 6. �̸� ���� ���� ������ �ݺ�
 */