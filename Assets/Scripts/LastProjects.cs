using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class LastProjects : MonoBehaviour {

    [SerializeField]
    public GameObject LastHolder;
    public GameObject Prefab;

    private string ProjectsDir;
    private List<string> files = new List<string>();

    void Start()
    {
        ProjectsDir = ProgManager.Instance.ProjectsDir;

        DirectoryInfo dir = new DirectoryInfo(ProjectsDir);

        foreach (FileInfo file in dir.GetFiles())
        {
            string name = Path.GetFileNameWithoutExtension(file.FullName);
            files.Add(name);

            GameObject t = Instantiate(Prefab);
            t.transform.SetParent(LastHolder.transform);
            t.transform.position = new Vector3(0, 0, 0);
            t.GetComponentInChildren<Text>().text = name;
            t.name = name;
        }

    }

    public void Refresh()
    {
        for (int i = 0; i < LastHolder.transform.childCount; i++)
        {
            Transform go = LastHolder.transform.GetChild(i);
            Destroy(go.GetComponent<Image>());
            Destroy(go);
        }

        DirectoryInfo dir = new DirectoryInfo(ProjectsDir);

        foreach (FileInfo file in dir.GetFiles())
        {
            string name = Path.GetFileNameWithoutExtension(file.FullName);
            files.Add(name);

            GameObject t = Instantiate(Prefab);
            t.transform.SetParent(LastHolder.transform);
            t.transform.position = new Vector3(0, 0, 0);
            t.GetComponentInChildren<Text>().text = name;
            t.name = name;
        }
    }
}
