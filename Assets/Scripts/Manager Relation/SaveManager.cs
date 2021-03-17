using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
public class SaveManager : SingletonMonoBehaviour<SaveManager>
{
    string filePath;
    SaveData save;
    MoveSceneManager moveSceneManager;

    void Awake()
    {

        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        filePath = Application.persistentDataPath + "/" + "savedata.json";
        save = new SaveData();

        moveSceneManager = GetComponent<MoveSceneManager>();

        if (Debug.isDebugBuild)
        {
            CreateDebugData();
        }
        else
        {
            if (File.Exists(filePath))
            {
                Load();
            }
            else
            {
                //初回起動時の設定
                //ステージ1だけフラグを立てて選択可能にする
                save.stageFlags = new bool[moveSceneManager.NumOfStage];
                save.stageFlags[1] = true;
                Save();
            }
        }
    }

    public void SetFlag(int stageIndex)
    {
        stageIndex = Mathf.Clamp(stageIndex, 0, moveSceneManager.NumOfStage - 1);
        save.stageFlags[stageIndex] = true;
    }

    public bool GetFlag(int stageIndex)
    {
        stageIndex = Mathf.Clamp(stageIndex, 0, moveSceneManager.NumOfStage - 1);
        return save.stageFlags[stageIndex];
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(save);

        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();

            save = JsonUtility.FromJson<SaveData>(data);
        }
    }

    public void InitSaveData()
    {
        save = new SaveData();
    }

    void CreateDebugData()
    {
        save.stageFlags = Enumerable.Repeat(true, moveSceneManager.NumOfStage).ToArray();
    }
}
