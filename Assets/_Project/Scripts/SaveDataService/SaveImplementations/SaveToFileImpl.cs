using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

namespace _Project.Scripts.SaveDataService.SaveImplementations
{
  /// \class SaveToFileImpl
  /// \brief Класс, отвечающий за сохранение данных в файл (Альтернативный способ сохранения)
  [UsedImplicitly]
  public class SaveToFileImpl : BaseSaveStrategy
  {
    /// \brief Директория для сохранения
    private readonly string _baseFileDirectoryPath = Path.Combine(Application.persistentDataPath, "Saves");
    
    /// \brief Метод загрузки коллекции сохраненных значений
    /// \param content   Строка в JSON формате
    /// \return Коллекция сохраненных значений
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
    
    /// \brief Метод записи коллекции сохраненных значений
    /// \param fileKey   Ключ файла для сохранения
    /// \param content   Строка в JSON формате
    public override void Write(string fileKey, string content)
    {
      if (!Directory.Exists(_baseFileDirectoryPath))
        Directory.CreateDirectory(_baseFileDirectoryPath);
      
      string filePath = Path.Combine(_baseFileDirectoryPath, $"{fileKey}.json");
      File.WriteAllText(filePath, content);
    }
  }
}