using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SaveMaker : MonoBehaviour
{
    [SerializeField] TextAsset firstSet;

    private GameData gameData;
    public GameData GameData { get { return gameData; } }
        
#if UNITY_EDITOR
    private string path => Path.Combine(Application.dataPath, $"Resources/Data/SaveLoad");
#else
    private string path => Path.Combine(Application.persistentDataPath, $"Resources/Data/SaveLoad");
#endif

    private void Start()
    {
        // 0�� ���̺갡 �����ϴ��� Ȯ��
        if (Manager.Data.ExistData(0))
            return;

        // FisrtSet�� �ҷ��ͼ� GameData�� �����Ѵ�
        //string json = File.ReadAllText($"{setPath}/FirstSet.txt");
        string json = firstSet.text;
        if (json == null)
            Debug.LogError("Json is null!!");

        gameData = JsonUtility.FromJson<GameData>(json);

        // �� GameData�� �ٽ� 0�� Save�� �����
        if (Directory.Exists(path) == false)        // ������ �ִ��� Ȯ���Ѵ�
        {
            Directory.CreateDirectory(path);
        }

        string jsonSave = JsonUtility.ToJson(gameData, true);
        File.WriteAllText($"{path}/0.txt", jsonSave);
    }
}
