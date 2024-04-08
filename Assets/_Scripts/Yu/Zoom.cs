using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera FPSCamera;
    [SerializeField] CinemachineVirtualCamera ZoomCamera;
    [SerializeField] Image scope;

    CinemachineVirtualCamera curCamera;

    private void Start()
    {
        curCamera = FPSCamera;
    }

    /// <summary>
    /// ��Ŭ�� �ÿ� ���� ���ְ� ī�޶��� ������ �ٲٴ� �Լ�
    /// </summary>
    /// <param name="value"></param>
    void OnZoom(InputValue value)
    {
        if (curCamera == FPSCamera)
        {
            curCamera = ZoomCamera;
            ZoomCamera.Priority = 11;
            scope.gameObject.SetActive(true);
        }
        else
        {
            curCamera = FPSCamera;
            ZoomCamera.Priority = 1;
            scope.gameObject.SetActive(false);
        }
    }
}
