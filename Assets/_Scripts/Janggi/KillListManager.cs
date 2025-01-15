using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 개발자: Yerin
/// 
/// 장기씬 잡은 말 표시 UI를 위한 싱글톤
/// </summary>

public class KillListManager : Singleton<KillListManager>
{
    [SerializeField] GameObject hanFirst;
    [SerializeField] GameObject hanSecond;
    [SerializeField] GameObject choFirst;
    [SerializeField] GameObject choSecond;

    [SerializeField] Image[] hanImage;
    [SerializeField] Image[] choImage;

    public Image[] HanImage { get { return hanImage; } }
    public Image[] ChoImage { get { return choImage; } }

    private void Start()
    {
        hanImage = new Image[15];
        choImage = new Image[15];

        InitializeImageArray(hanImage, hanFirst, hanSecond);    // 한나라 Kill 이미지 관리 배열 초기화
        InitializeImageArray(choImage, choFirst, choSecond);    // 초나라 Kill 이미지 관리 배열 초기화
    }

    /// <summary>
    /// Lill List의 장기말 이미지를 이를 관리하는 배열에 넣기 위한 메서드
    /// </summary>
    /// <param name="whoesImage">각 나라의 이미지 관리하는 배열</param>
    /// <param name="firstImageBox">UI 첫번째 줄 장기말 이미지가 담긴 오브젝트</param>
    /// <param name="secondImageBox">UI 두번째 줄 장기말 이미지가 담긴 오브젝트</param>
    private void InitializeImageArray(Image[] whoesImage, GameObject firstImageBox, GameObject secondImageBox)
    {
        int count = 0;

        foreach (Image image in firstImageBox.transform.GetComponentsInChildren<Image>())
        {
            whoesImage[count++] = image;
        }

        foreach (Image image in secondImageBox.transform.GetComponentsInChildren<Image>())
        {
            whoesImage[count++] = image;
        }
    }

    public void SetImageNum()
    {
        int hanCount = 0;
        int choCount = 0;

        foreach (Cha cha in FindObjectsOfType<Cha>())   // cha
        {
            if (cha.WhosPiece.Equals("Han"))
            {
                cha.ImageNum = hanCount++;
            }
            else
            {
                cha.ImageNum = choCount++;
            }
        }

        foreach (Sang sang in FindObjectsOfType<Sang>())    // Sang
        {
            if (sang.WhosPiece.Equals("Han"))
            {
                sang.ImageNum = hanCount++;
            }
            else
            {
                sang.ImageNum = choCount++;
            }
        }

        foreach (Ma ma in FindObjectsOfType<Ma>())  // Ma
        {
            if (ma.WhosPiece.Equals("Han"))
            {
                ma.ImageNum = hanCount++;
            }
            else
            {
                ma.ImageNum = choCount++;
            }
        }

        foreach (Po po in FindObjectsOfType<Po>())  // Po
        {
            if (po.WhosPiece.Equals("Han"))
            {
                po.ImageNum = hanCount++;
            }
            else
            {
                po.ImageNum = choCount++;
            }
        }

        foreach (Sa sa in FindObjectsOfType<Sa>())  // Sa
        {
            if (sa.WhosPiece.Equals("Han"))
            {
                sa.ImageNum = hanCount++;
            }
            else
            {
                sa.ImageNum = choCount++;
            }
        }

        foreach (Jol jol in FindObjectsOfType<Jol>())  // Jol
        {
            if (jol.WhosPiece.Equals("Han"))
            {
                jol.ImageNum = hanCount++;
            }
            else
            {
                jol.ImageNum = choCount++;
            }
        }
    }

    public void SetHanKill(int num)
    {
        hanImage[num].color = Color.HSVToRGB(0, 0, 1);
    }

    public void SetChoKill(int num)
    {
        choImage[num].color = Color.HSVToRGB(0, 0, 1);
    }
}

