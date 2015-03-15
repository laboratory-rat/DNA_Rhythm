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

    public DNA_Data data;

    private string DataDir = "Data";

    void Awake()
    {
        _instance = this;

        if (!Directory.Exists(DataDir)) Directory.CreateDirectory(DataDir);
    }
}

[System.Serializable]
public class DNA_Data
{
    public string ProjectName;
    public string DNA_String;
    public string[] Triplets;

    public DNA_Data(string name, string data)
    {
        ProjectName = name;
        DNA_String = data;
    }
}