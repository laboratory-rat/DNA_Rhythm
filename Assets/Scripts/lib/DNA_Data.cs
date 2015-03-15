using System.Collections.Generic;

[System.Serializable]
public class DNA_Data
{
    public string ProjectName;
    public string DNA_String;
    public List<string> Triplets = new List<string>();

    public DNA_Data(string name, string data)
    {
        ProjectName = name;
        DNA_String = data;

        for (int i = 0; i < DNA_String.Length; i += 3)
        {
            if (i + 2 > DNA_String.Length) break;
            Triplets.Add(DNA_String.Substring(i, 3));
        }
    }
}