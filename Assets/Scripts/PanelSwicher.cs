using UnityEngine;
using System.Collections;

public class PanelSwicher : MonoBehaviour
{

    public GameObject[] Panels;

    public GameObject ActivePanel;

    void Awake()
    {
        foreach (GameObject go in Panels)
        {
            bool active = (go == ActivePanel) ? true : false;
            go.SetActive(active);
        }
    }

    public void SwichPanel(GameObject panel)
    {
        if (ActivePanel == panel)
        {
            panel.SetActive(!panel.activeInHierarchy);
        }
        else
        {
            if (ActivePanel != null) ActivePanel.SetActive(false);
            ActivePanel = panel;
            ActivePanel.SetActive(true);
        }
    }
}
