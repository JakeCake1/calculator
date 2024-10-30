namespace _Project.Scripts.SaveDataService.Interfaces
{
  /// \interface ISaveDataService
  /// \brief Интерфейс, отвечающий за работу с сохраненными данными
  public interface ISaveDataService
  {
    /// \brief Метод загрузки сохраненных данных
    void Load();
    /// \brief Метод записи данных в файлы/классы
    void Write();
    /// \brief Метод сохранения значения
    /// \param subFile   Ключ файла для сохранения
    /// \param key   Ключ значения
    /// \param value   Значение
    void Save(string subFile, string key, object value);
    /// \brief Метод получения значения
    /// \param subFile   Ключ файла для сохранения
    /// \param key   Ключ значения
    /// \return Значение по переданному типу
    T Get<T>(string subFile, string key);
  } 
}