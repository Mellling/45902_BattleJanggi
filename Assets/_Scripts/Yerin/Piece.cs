using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// ������: Yerin
/// 
/// ��⸻�� ��� ����
/// </summary>
public class Piece : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected Spot[,] JanggiSituation;    // ���� ����� �� ���� ��Ȳ�� �޾� �� �迭

    Material pieceMaterial; // �ش� ��⸻�� Material�� ���� ����

    protected string pieceName;

    private string whosPiece;

    public string PieceName { get { return pieceName; } }

    public string WhosPiece { get { return whosPiece; } }

    protected virtual void Start()
    {
        pieceMaterial = gameObject.GetComponent<Renderer>().material;
    }

    /// <summary>
    /// �ش� ��⸻ ���� �� ������� ��ü���� ��Ȳ �޾ƿ�
    /// �÷��̾ ��⸻�� ���� �� �ش� ������Ʈ�� ���� ���������� ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        JanggiSituation = Manager.JanggiLogic.JanggiLogicSituation;

        if (JanggiSituation == null)
        {
            Debug.Log("Get JanggiLogic Fail");
        }

        pieceMaterial.color = Color.red;

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                JanggiSituation[i, j].gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }

        FindCanGo();
    }
    /// <summary>
    /// �÷��̾ �ش� ��⸻ ���� ���콺�� �ø� �� ������Ʈ�� ���� ��������� ����
    /// ������ �� ������ �˷��ֱ� ����
    /// </summary>
    /// <param name="eventData"></param>

    public void OnPointerEnter(PointerEventData eventData)
    {
        pieceMaterial.color = Color.yellow;
    }

    /// <summary>
    /// �÷��̾ �ش� ��⸻�� �������� �ʰ� ������ �� ������Ʈ�� ���� ������� ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (pieceMaterial.color == Color.red)
        {
            return;
        }

        pieceMaterial.color = Color.white;
    }

    public virtual void FindCanGo()
    {

    }
}
