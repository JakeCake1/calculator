using System.Collections.Generic;

namespace _Project.Scripts.SaveDataService
{
  /// \class BaseSaveStrategy
  /// \brief Класс, отвечающий за алгоритм сохранения данных
  public abstract class BaseSaveStrategy
  {
    /// \brief Метод загрузки коллекции сохраненных значений
    /// \param content   Строка в JSON формате
    /// \return Коллекция сохраненных значений
    public abstract Dictionary<string, string> Load();
    /// \brief Метод записи коллекции сохраненных значений
    /// \param fileKey   Ключ файла для сохранения
    /// \param content   Строка в JSON формате
    public abstract void Write(string fileKey, string content);
  }
}