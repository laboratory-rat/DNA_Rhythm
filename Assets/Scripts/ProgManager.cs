using UnityEngine;
using System.Collections;
using System.IO;

public class ProgManager : MonoBehaviour {

    public static ProgManager Instance = null;
    private ProgManager _instance
    {
        get { return Instance; }
        set
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else Destroy(this);
        }
    }

    public DNA_Data Data;

    private SaveLoad saveLoad;

    public readonly string DataDir = "Data/";
    public readonly string ProjectsDir = "Projects/";

    void Awake()
    {
        _instance = this;

        if (!Directory.Exists(DataDir)) Directory.CreateDirectory(DataDir);
        if (!Directory.Exists(ProjectsDir)) Directory.CreateDirectory(ProjectsDir);
    }

    public void NewData(string name, string data)
    {
        Data = new DNA_Data(name, data);
        Debug.Log("Data: " + data);
        saveLoad = new SaveLoad(ProjectsDir);
        saveLoad.SaveProject(Data.ProjectName, Data, false);
        if (!saveLoad.success) Debug.LogError("Невозможно сохранить файл!");
    }
}