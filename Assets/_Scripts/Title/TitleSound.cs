using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
/// <summary>
/// ���� : ����
/// Ÿ��Ʋ������ ����ϴ� �ɼ��� ���弼��
/// </summary>
public class TitleSound : MonoBehaviour
{
    [SerializeField] Button BGMOnButton;
    [SerializeField] Button SFXOnButton;
    [SerializeField] Button BGMOffButton;
    [SerializeField] Button SFXOffButton;
        
    public void BGMOn()
    {
        BGMOffButton.gameObject.SetActive(false);
        BGMOnButton.gameObject.SetActive(true);
        Manager.Sound.mixer.SetFloat("BGM", 0);
    }

    public void BGMOff()
    {
        BGMOffButton.gameObject.SetActive(true);
        BGMOnButton.gameObject.SetActive(false);
        Manager.Sound.mixer.SetFloat("BGM", -80);
    }

    public void SFXOn()
    {
        SFXOffButton.gameObject.SetActive(false);
        SFXOnButton.gameObject.SetActive(true);
        Manager.Sound.mixer.SetFloat("SFX", 0);
    }

    public void SFXOff()
    {
        SFXOffButton.gameObject.SetActive(true);
        SFXOnButton.gameObject.SetActive(false);
        Manager.Sound.mixer.SetFloat("SFX", -80);
    }
}
