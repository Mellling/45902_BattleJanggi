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

    float baseTime = 60;
    float timer;
    int turn;       // �� �� üũ
    int hanSa = 2;  // �ѳ����� ���� ����
    int choSa = 2;  // �ʳ����� ���� ����

    bool canGoOut;

    Coroutine timeLimit;

    public string CurrentTurn { get { return currentTurn; } }
    public bool CanGoOut { get {  return canGoOut; } }
    public float Timer {  get { return timer; } }
    public int Turn { get { return turn; } set { turn = value; } }
    public int HanSa { get {  return hanSa; } set {  hanSa = value; } }
    public int ChoSa { get { return choSa; } set {  choSa = value; } }

    private void Start()
    {
        currentTurn = Han;

        timer = baseTime;
        turn = 0;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
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
            turn++;
            timer = baseTime;
        }
        else if (currentTurn.Equals(Cho))   // ���� �÷��̾ �ʳ����� ��
        {
            currentTurn = Han;
            turn++;
            timer = baseTime;
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

    public void StopTurnCount()
    {
        StopCoroutine(timeLimit);
    }

    public void StartTurnCount()
    {
        timeLimit = StartCoroutine(CountTime());
    }
}