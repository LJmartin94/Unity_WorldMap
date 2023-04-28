using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileHelper
{
    public static string MakePath(params string[] dirNames)
    {
        return Path.Combine(dirNames);
    }

    public static string PersistentDataPath
    {
        get
        {
            return Application.persistentDataPath;
        }
    }

    public static void SaveTextToFile(string path, 
                                      string fileName, 
                                      string fileExtension,
                                      string data,
                                      bool log = false)
    {
        if (fileExtension[0] != '.')
        {
            fileExtension = "." + fileExtension;
        }
        string file = Path.Combine(path, fileName + fileExtension);
        SaveTextToFile(file, data, log);
    }

    public static void SaveTextToFile(string fullPath, string data, bool log = false)
    {
        StreamWriter writer = new StreamWriter(File.Open(fullPath, FileMode.Create));
        writer.Write(data);

        if (log)
            Debug.Log("Wrote to: " + fullPath);
    }
}
