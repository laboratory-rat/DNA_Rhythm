using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

[SerializeField]
public class Parse : MonoBehaviour {

    public Button ParseFileButton;
    public Button ParseStringButton;

    public InputField ParseFileInput;
    public InputField ParseStringInput;
    public InputField ProjectName;

    private string data;
    private string name;

    public void ParseFromFile()
    {
        if (!CheckFields(ParseFileInput))
        {
            Debug.Log("Поля не могут быть пустыми!");
            return;
        }

        if (ParseFileButton == null || ParseFileInput == null)
        {
            Debug.Log("No button or InputField!");
            return;
        }

        string DataDir = ProgManager.Instance.DataDir;
        string FileName = ParseFileInput.text;
        string file = DataDir + FileName;

        if (!File.Exists(file))
        {
            Debug.Log("Файла не существует!");
            return;
        }

        data = File.ReadAllText(file).ToUpper();
        name = ProjectName.text;

        ProgManager.Instance.NewData(name, data);
        
    }

    private bool CheckFields(InputField field)
    {
        if (field.text == "" || ProjectName.text == "") return false;
        return true;
    }
}
