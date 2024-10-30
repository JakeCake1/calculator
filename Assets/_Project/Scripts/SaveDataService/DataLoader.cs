using System.Collections.Generic;
using _Project.Scripts.SaveDataService.Interfaces;
using Newtonsoft.Json;

namespace _Project.Scripts.SaveDataService
{
  /// \class DataLoader
  /// \brief Класс, отвечающий за конвертирование сохраненных данных
  public class DataLoader : IDataLoader
  {
    /// \brief Метод конвертирования JSON в коллекцию
    /// \param content   Строка в JSON формате
    /// \return Коллекция сохраненных значений
    public Dictionary<string, object> ConvertDataForReading(string content) => 
      JsonConvert.DeserializeObject<Dictionary<string, object>>(content);
    
    /// \brief Метод конвертирования коллекции в JSON
    /// \param savedValues   Коллекция сохраненных значений
    /// \return Строка в JSON формате
    public string ConvertDataForSaving(Dictionary<string, object> savedValues) => 
      JsonConvert.SerializeObject(savedValues);
  }
}