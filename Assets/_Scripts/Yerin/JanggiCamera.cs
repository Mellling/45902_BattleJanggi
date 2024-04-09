using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������: Yerin
/// 
/// ���� ī�޶� ��ȯ ���� Ŭ����
/// </summary>
public class JanggiCamera : Singleton<JanggiCamera>
{
    [SerializeField] CinemachineVirtualCamera hanLowCam;
    [SerializeField] CinemachineVirtualCamera hanChooseCam;
    [SerializeField] CinemachineVirtualCamera choLowCam;
    [SerializeField] CinemachineVirtualCamera choChooseCam;

    CinemachineVirtualCamera currentCam;

    private void Start()
    {
        currentCam = hanLowCam;
    }

    /// <summary>
    /// ī�޶� ������ ���̷� �ø��� �۾�
    /// </summary>
    public void CameraMoveHigh()
    {
        if (Manager.JanggiTurn.CurrentTurn.Equals("Han"))   // �ѳ����� HighCam���� �̵��ؾ� �� ��
        {
            hanChooseCam.Priority = 20;
            currentCam.Priority = 10;

            currentCam = hanChooseCam;
        }
        else if (Manager.JanggiTurn.CurrentTurn.Equals("Cho"))  // �ʳ����� HighCam���� �̵��ؾ� �� ��
        {
            choChooseCam.Priority = 20;
            currentCam.Priority = 10;

            currentCam = choChooseCam;
        }
    }

    /// <summary>
    /// ī�޶� ������ �ο�� ������ �۾�
    /// </summary>
    public void CameraMoveLow()
    {
        if (Manager.JanggiTurn.CurrentTurn.Equals("Han"))   // �ѳ����� LowCam���� �̵��ؾ� �� ��
        {
            hanLowCam.Priority = 20;
            currentCam.Priority = 10;

            currentCam = hanLowCam;
        }
        else if (Manager.JanggiTurn.CurrentTurn.Equals("Cho"))  // �ʳ����� LowCam���� �̵��ؾ� �� ��
        {
            choLowCam.Priority = 20;
            currentCam.Priority= 10;

            currentCam = choLowCam;
        }
    }
}
