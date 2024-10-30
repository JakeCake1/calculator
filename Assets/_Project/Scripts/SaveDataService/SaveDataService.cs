using System.Collections.Generic;
using _Project.Scripts.SaveDataService.Interfaces;

namespace _Project.Scripts.SaveDataService
{  
  /// \class SaveDataService
  /// \brief Класс, отвечающий за работу с сохраненными данными
  public sealed class SaveDataService : ISaveDataService
  {
    /// \brief Коллекция сохраненных значений
    private readonly Dictionary<string, Dictionary<string, object>> _savedValues = new();
    
    /// \brief Алгоритм сохранения данных
    private readonly BaseSaveStrategy _saveStrategy;
    /// \brief Загрузчик сохраненных данных
    private readonly IDataLoader _dataLoader;
    
    /// \brief Конструктор сервиса сохранения
    /// \param saveStrategy   Алгоритм сохранения данных
    /// \param dataLoader   Загрузчик сохраненных данных
    public SaveDataService(BaseSaveStrategy saveStrategy, IDataLoader dataLoader)
    {
      _dataLoader = dataLoader;
      _saveStrategy = saveStrategy;
    }
    
    /// \brief Метод загрузки сохраненных данных
    public void Load()
    {
      Dictionary<string, string> savedValues = _saveStrategy.Load();

      foreach (var savedPair in savedValues)
        _savedValues[savedPair.Key] = _dataLoader.ConvertDataForReading(savedPair.Value);
    }
    
    /// \brief Метод записи данных в файлы/классы
    public void Write()
    {
      foreach (var savedPair in _savedValues)
        _saveStrategy.Write(savedPair.Key, _dataLoader.ConvertDataForSaving(savedPair.Value));
    }
    
    /// \brief Метод сохранения значения
    /// \param subFile   Ключ файла для сохранения
    /// \param key   Ключ значения
    /// \param value   Значение
    public void Save(string subFile, string key, object value)
    {
      if (!_savedValues.ContainsKey(subFile))
        _savedValues.Add(subFile, new Dictionary<string, object>());

      _savedValues[subFile][key] = value;
    }
    
    /// \brief Метод получения значения
    /// \param subFile   Ключ файла для сохранения
    /// \param key   Ключ значения
    /// \return Значение по переданному типу
    public T Get<T>(string subFile, string key)
    {
      if (!_savedValues.ContainsKey(subFile))
        return default;

      if (!_savedValues[subFile].ContainsKey(key))
        return default;

      return (T)_savedValues[subFile][key];
    }
  }
}