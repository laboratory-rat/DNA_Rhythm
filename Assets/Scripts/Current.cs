using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[SerializeField]
public class Current : MonoBehaviour {

    public Text Name;
    public GameObject GraphHolder;
    public InputField TripletsHolder;

    private DNA_Data Data;
    private string[] Nucleo = { "A", "T", "C", "G" };
    private List<string> TriplCount = new List<string>();
    private List<Triplet> TripletsData = new List<Triplet>();

    private Dictionary<string, float> Count = new Dictionary<string, float>();
    private string[,] Result;

    void OnEnable()
    {
        if (ProgManager.Instance.Data == null)
        {
            Name.text = "Null";
            return;
        }

        Data = ProgManager.Instance.Data;
        Name.text = Data.ProjectName;

        string OutTriplets = "";
        foreach (string st in Data.Triplets)
        {
            OutTriplets += st + " ";
        }
        TripletsHolder.text = OutTriplets;
    }

    public void Generate()
    {
        if (Data == null) return;

        string f, s, t;

        for (int i = 0; i < Nucleo.Length; i++)
        {
            f = Nucleo[i];
            for (int j = 0; j < Nucleo.Length; j++)
            {
                s = Nucleo[j];
                for (int k = 0; k < Nucleo.Length; k++)
                {
                    t = Nucleo[k];
                    string result = Nucleo[i] + Nucleo[j] + Nucleo[k];
                    TriplCount.Add(result);
                }
            }
        }

        foreach (string triplet in Data.Triplets)
        {
            Triplet newTriplet = new Triplet(triplet, TriplCount);
            TripletsData.Add(newTriplet);
        }

        Result = new string[TripletsData.Count, 5];
        Result.Initialize();

        for (int i = 0; i < TripletsData.Count; i++)
        {
            Count = new Dictionary<string,float>();
            if (i - 4 > 0)
            {
                Triplet tr = TripletsData[i - 4];
                Plus(tr.Cor);
            }
            if (i - 3 > 0)
            {
                Triplet tr = TripletsData[i - 3];
                Plus(tr.Cor);
            }
            if (i - 2 > 0)
            {
                Triplet tr = TripletsData[i - 2];
                Plus(tr.Cor);
            }
            if (i - 1 > 0)
            {
                Triplet tr = TripletsData[i - 1];
                Plus(tr.Cor);
            }
            
            Triplet tr2 = TripletsData[i];
            Plus(tr2.Cor);

            if (i + 1 < TripletsData.Count)
            {
                Triplet tr = TripletsData[i + 1];
                Plus(tr.Cor);
            }
            if (i + 2 < TripletsData.Count)
            {
                Triplet tr = TripletsData[i + 2];
                Plus(tr.Cor);
            }
            if (i + 3 < TripletsData.Count)
            {
                Triplet tr = TripletsData[i + 3];
                Plus(tr.Cor);
            }
            if (i + 4 < TripletsData.Count)
            {
                Triplet tr = TripletsData[i + 4];
                Plus(tr.Cor);
            }

            int k = 0;
            foreach (KeyValuePair<string, float> kvp in Count)
            {
                if (k > 4) break;
                if(kvp.Value > 0.5)
                {
                    Result[i, k] = kvp.Key;
                }
            }
        }

        //Finish
        for (int i = 0; i < Result.Length - 1; i++)
        {
            Debug.Log("Triplet № " + i);
            for (int k = 0; k < 5; k++)
            {
                Debug.Log(Result[i, k]);
            }
            Debug.Log("End Of " + i);
        }
    }

    void Plus(Dictionary<string, float> cor)
    {
        foreach (KeyValuePair<string, float> kvp in cor)
        {
            if (Count.ContainsKey(kvp.Key))
            {
                Count[kvp.Key] += kvp.Value;
            }
            else
            {
                Count.Add(kvp.Key, kvp.Value);
            }
            
        }
    }
}

public class Triplet
{
    public string Name;
    public Dictionary<string, float> Cor = new Dictionary<string, float>();
    public List<string> TripletsCount;

    public Triplet(string name, List<string> triplCount)
    {
        this.Name = name;
        this.TripletsCount = triplCount;

        foreach (string tripl in TripletsCount)
        {
            float count = 1f;

            for (int i = 0; i < 3; i++)
            {
                if (name[i] != tripl[i]) count -= 0.25f;
            }

            Cor.Add(tripl, count);
        }
    }
}
