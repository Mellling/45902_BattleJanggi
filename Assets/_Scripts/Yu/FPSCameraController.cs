using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
/// <summary>
/// ���� : ����
/// FPSī�޶��� ������ ���� Ŭ����
/// </summary>
public class FPSCameraController : MonoBehaviour
{
    [SerializeField] Transform cameraRoot;
    [SerializeField] Transform muzzlePointRoot;

    [SerializeField] float mouseSensitivity;
    [SerializeField] float xRotation;

    Vector2 inputDir;

    private void Update()
    {
        xRotation -= inputDir.y * mouseSensitivity * 2f * Time.deltaTime;           // x���� �������� ���Ʒ�
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);                              // ȸ�� ������ �����Ѵ�

        transform.Rotate(Vector3.up, inputDir.x * mouseSensitivity * 2f * Time.deltaTime);      // �¿�� ������ ������ ����
        cameraRoot.localRotation = Quaternion.Euler(xRotation, 0, 0);                           // ���ϴ� ī�޶� �������ش�
        muzzlePointRoot.localRotation = Quaternion.Euler(xRotation, 0, 0);                      // źȯ�� �߻�Ǵ� ��ġ�� ī�޶�� �����ϰ� �������ش�
        //cameraRoot.Rotate(Vector3.right, -inputDir.y * mouseSensitivity * Time.deltaTime);
    }

    void OnLook(InputValue value)
    {
        inputDir = value.Get<Vector2>();
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
