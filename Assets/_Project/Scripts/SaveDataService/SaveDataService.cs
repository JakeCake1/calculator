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

    public void SaveString(string subFile, string key, string value) =>
      _savedValues[subFile][key] = value;

    public void SaveInt(string subFile, string key, int value) =>
      _savedValues[subFile][key] = value;

    public void SaveFloat(string subFile, string key, float value) =>
      _savedValues[subFile][key] = value;

    public void SaveBool(string subFile, string key, bool value) =>
      _savedValues[subFile][key] = value;

    
    public string GetString(string subFile, string key) =>
      (string)_savedValues[subFile][key];

    public int GetInt(string subFile, string key) =>
      (int)_savedValues[subFile][key];

    public float GetFloat(string subFile, string key) =>
      (float)_savedValues[subFile][key];

    public bool GetBool(string subFile, string key) =>
      (bool)_savedValues[subFile][key];
  }
}