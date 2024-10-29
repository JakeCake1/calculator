using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace _Project.Scripts.SaveDataService.SaveImplementations
{
  public class SaveToFileImpl : BaseSaveStrategy
  {
    private readonly string _baseFileDirectoryPath = Path.Combine(Application.persistentDataPath, "Saves");
    
    public override Dictionary<string, string> Load()
    {
      if (!Directory.Exists(_baseFileDirectoryPath))
        return new Dictionary<string, string>();
      
      string[] files = Directory.GetFiles(_baseFileDirectoryPath);

      Dictionary<string, string> savedData = new Dictionary<string, string>();
      
      foreach (string file in files) 
        savedData.Add(Path.GetFileNameWithoutExtension(file), File.ReadAllText(Path.Combine(_baseFileDirectoryPath, file)));

      return savedData;
    }

    public override void Write(string fileKey, string content)
    {
      if (!Directory.Exists(_baseFileDirectoryPath))
        Directory.CreateDirectory(_baseFileDirectoryPath);
      
      string filePath = Path.Combine(_baseFileDirectoryPath, $"{fileKey}.json");
      File.WriteAllText(filePath, content);
    }
  }
}