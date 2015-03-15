using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad {

    public bool success = false;
    public string Path;

    public SaveLoad(string path)
    {
        Path = path;
    }

    public void SaveProject(string name, DNA_Data data, bool rewrite)
    {
        string file = Path + name;

        if (File.Exists(file))
        {
            if (rewrite)
            {
                File.Delete(file);
            }
            else
            {
                return;
            }
        }

        FileStream fs = new FileStream(file, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, data);
        fs.Close();
        success = true;
    }
}
