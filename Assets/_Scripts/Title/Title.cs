using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� : ����
/// Ÿ��Ʋ������ ����ϴ� ��ɵ�
/// </summary>
public class Title : BaseScene
{
    [SerializeField] GameObject SoundUI;

    bool isOn;

    private void Start()
    {
        isOn = false;
        Manager.Sound.PlayBGM("BGM");
    }

    public void StartGame()
    {
        Manager.Scene.LoadScene("JanggiScene");
    }

    public void ClickOption()
    {
        if (!isOn)
        {
            isOn = true;
            SoundUI.SetActive(true);
        }
        else
        {
            isOn = false;
            SoundUI.SetActive(false);
        }
    }

    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
}
