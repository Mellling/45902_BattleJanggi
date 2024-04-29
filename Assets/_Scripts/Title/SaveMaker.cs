using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class SaveMaker : MonoBehaviour
{
    private GameData gameData;
    public GameData GameData { get { return gameData; } }

    private string setPath => Path.Combine(Application.dataPath, $"Resources/Data/FirstSet");

#if UNITY_EDITOR
    private string path => Path.Combine(Application.dataPath, $"Resources/Data/SaveLoad");
#else
    private string path => Path.Combine(Application.persistentDataPath, $"Resources/Data/SaveLoad");
#endif

    private void Start()
    {
        if (Manager.Data.ExistData(0))
            return;

        // FisrtSet�� �ҷ��ͼ� GameData�� �����Ѵ�
        string json = File.ReadAllText($"{setPath}/FirstSet.txt");
        gameData = JsonUtility.FromJson<GameData>(json);

        // �� GameData�� �ٽ� 0�� Save�� �����
        if (Directory.Exists(path) == false)
        {
            Directory.CreateDirectory(path);
        }

        string jsonSave = JsonUtility.ToJson(gameData, true);
        File.WriteAllText($"{path}/0.txt", jsonSave);
    }
}
