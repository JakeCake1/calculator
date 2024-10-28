using System.Collections.Generic;
using _Project.Scripts.SaveDataService.Interfaces;

namespace _Project.Scripts.SaveDataService
{
  public sealed class SaveDataService : ISaveDataService
  {
    private readonly Dictionary<string, Dictionary<string, object>> _savedValues = new();

    private readonly BaseSaveStrategy _saveStrategy;
    private readonly IDataLoader _dataLoader;

    public SaveDataService(BaseSaveStrategy saveStrategy, IDataLoader dataLoader)
    {
      _dataLoader = dataLoader;
      _saveStrategy = saveStrategy;
    }

    public void Load()
    {
      Dictionary<string, string> savedValues = _saveStrategy.Load();

      foreach (var savedPair in savedValues)
        _savedValues[savedPair.Key] = _dataLoader.ConvertDataForReading(savedPair.Value);
    }

    public void Write()
    {
      foreach (var savedPair in _savedValues)
        _saveStrategy.Write(savedPair.Key, _dataLoader.ConvertDataForSaving(savedPair.Value));
    }

    public void Save(string subFile, string key, object value)
    {
      if (!_savedValues.ContainsKey(subFile))
        _savedValues.Add(subFile, new Dictionary<string, object>());

      _savedValues[subFile][key] = value;
    }

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