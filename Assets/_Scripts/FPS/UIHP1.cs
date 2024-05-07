using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���� : ����
/// �÷��̾�1�� ü�¹�
/// </summary>
public class UIHP1 : MonoBehaviour
{
    [SerializeField] Slider hpBar;

    [SerializeField] UIPlayer1 uiplayer1;

    private void LateUpdate()
    {
        float hpPer = uiplayer1.Player1.HP / 100f;
        hpBar.value = hpPer;
    }
}
