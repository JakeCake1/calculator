using System.Collections.Generic;

namespace _Project.Scripts.SaveDataService.Interfaces
{
  /// \interface IDataLoader
  /// \brief Интерфейс, отвечающий за конвертирование сохраненных данных
  public interface IDataLoader
  {
    /// \brief Метод конвертирования JSON в коллекцию
    /// \param content   Строка в JSON формате
    /// \return Коллекция сохраненных значений
    Dictionary<string, object> ConvertDataForReading(string content);
    /// \brief Метод конвертирования коллекции в JSON
    /// \param savedValues   Коллекция сохраненных значений
    /// \return Строка в JSON формате
    string ConvertDataForSaving(Dictionary<string, object> savedValues);
  }
}